using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PostManager.Application.Common.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Infrastructure.Persistance.Identity
{
    public class TokenClaimService : ITokenClaimService
    {
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _jwtSettings;
        public TokenClaimService(IConfiguration configuration)
        {
            _configuration = configuration;
            _jwtSettings = _configuration.GetSection("JwtSettings");
        }
        public string GetToken(string email, string userId, List<string> currentClaims)
        {

            Claim[] userClaims = new Claim[currentClaims.Count];
            for (int i = 0; i < userClaims.Length; i++)
            {

                var claimToAdd = new Claim("Application.Permission", currentClaims[i]);
                userClaims[i] = claimToAdd;
            }
            var claims = new[]
              {
                new Claim("UserId",userId),
                new Claim(JwtRegisteredClaimNames.Email,email)
                ,
            }.Union(userClaims).ToArray();
            var credentials = GetSigningCredentials();
            var tokenOptions = GenerateTokenOptions(credentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return token;
        }
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, Claim[] claims)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtSettings.GetSection("validIssuer").Value,
                audience: _jwtSettings.GetSection("validAudience").Value,
                claims: claims,
                expires: DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.GetSection("expiryInDays").Value)),
                signingCredentials: signingCredentials);
            return tokenOptions;

        }
        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("securityKey").Value);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
    }
}
