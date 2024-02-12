using Microsoft.AspNetCore.Identity;
using PostManager.Application.Common.Contracts;
using PostManager.Application.Common.Models.Authentication;
using PostManager.Application.Common.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Infrastructure.Persistance.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ITokenClaimService _jwtHandler;
        public IdentityService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, ITokenClaimService jwtHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _jwtHandler = jwtHandler;

        }
        public Task<UserModel> GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthenticationResultModel> LoginJwt(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, password))
                throw new Exception("Invalid Authentication");
            var role = await _userManager.GetRolesAsync(user);
            var roleName = role.FirstOrDefault();
            var currentRole = await _roleManager.FindByNameAsync(roleName);
            var roleClaims = await _roleManager.GetClaimsAsync(currentRole);
            var currentClaims = roleClaims.Select(r => r.Value).ToList();
            var token = _jwtHandler.GetToken(user.Email, user.Id.ToString(), currentClaims);
            var currentUser = new AuthUserModel(
                  user.Id.ToString(),
                user.UserName,
                  user.Email

            );
            var authResult = new AuthenticationResultModel(currentUser, token);

            return authResult;

        }

        public async Task<bool> Register(string email, string username, string password)
        {
            var checkIfUserExists = await _userManager.FindByEmailAsync(email);
            if(checkIfUserExists != null)
            {
                throw new Exception("Invalid Email");
            }
            var checkIfUsernameExists = await _userManager.FindByNameAsync(username);
            if(checkIfUsernameExists != null)
            {
                throw new Exception("Invalid Username");
            }
            var userToCreate = new User
            {
                UserName = username,
                NormalizedUserName = username.ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                Email = email,
                NormalizedEmail = email.ToUpper(),
            };
            var userStatus = await _userManager.CreateAsync(userToCreate, password);
            if(userStatus.Succeeded)
            {
                await _userManager.AddToRoleAsync(userToCreate, "user");
                return true;
            }
            else
            {
                throw new Exception("An error occurred");
            }
        }
    }
    }

