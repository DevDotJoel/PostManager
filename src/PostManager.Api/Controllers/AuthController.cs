using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PostManager.Api.Dtos.Auth;
using PostManager.Api.Dtos.User;
using PostManager.Api.Entities;
using PostManager.Api.IdentityService;

namespace PostManager.Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ITokenClaimService _jwtHandler;
        public AuthController(
            RoleManager<Role> roleManager,
            UserManager<User> userManager,
            ITokenClaimService jwtHandler
            )
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _jwtHandler = jwtHandler;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto registerUser)
        {
            var user = await _userManager.FindByEmailAsync(registerUser.Email);
            if (user == null)
            {
                var usernameAvailable = await _userManager.FindByNameAsync(registerUser.Username);
                if (usernameAvailable != null)
                {
                    throw new Exception("username already in use");
                }
                var createUser = new User
                {
                    UserName = registerUser.Username,
                    NormalizedUserName = registerUser.Username.ToUpper(),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true,
                    Email = registerUser.Email,
                    NormalizedEmail = registerUser.Email.ToUpper(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                var role = await _roleManager.Roles.Where(r => r.Name == "User").FirstOrDefaultAsync();
                await _userManager.CreateAsync(createUser, registerUser.Password);
                await _userManager.AddToRoleAsync(createUser, "User");
                var token = _jwtHandler.GetToken(createUser.Email, createUser.Id, role.Name);
                var currentUserDto = new UserDto();
                currentUserDto.Username = createUser.UserName;
                currentUserDto.Email = createUser.Email;
                return Ok(new { Token = token, User = currentUserDto });
            }
            else
            {
                throw new Exception("Email already in use");
            }


        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto loginUser)
        {
            var user = await _userManager.FindByEmailAsync(loginUser.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginUser.Password))
                throw new Exception("Invalid Authentication");
            var role = await _userManager.GetRolesAsync(user);
            var roleName = role.FirstOrDefault();
            var currentRole = await _roleManager.FindByNameAsync(roleName);
            var roleClaims = await _roleManager.GetClaimsAsync(currentRole);
            var currentClaims = roleClaims.Select(r => r.Value).ToList();
            var token = _jwtHandler.GetToken(user.Email, user.Id, roleName);
            var currentUser = new UserDto();
            currentUser.Username = user.UserName;
            currentUser.Email = user.Email;
            return Ok(new { Token = token, ExpirationDate = DateTime.Now.AddHours(24).ToString(), User = currentUser });


        }
    }
}
