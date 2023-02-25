using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PostManager.Api.IdentityService
{
    public class TokenClaimService:ITokenClaimService
    {
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _jwtSettings;
        public TokenClaimService(IConfiguration configuration)
        {
            _configuration = configuration;
            _jwtSettings = _configuration.GetSection("JwtSettings");
        }
        public string GetToken(string email, int userId, string role)
        {
       
            var claims = new[]
              {
                new Claim(JwtRegisteredClaimNames.Sub,userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,email),
                new Claim(ClaimTypes.Role, role)
                ,
            }.ToArray();
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
