using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpPost("Register")]
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
                await _userManager.CreateAsync(createUser,registerUser.Password);
                await _userManager.AddToRoleAsync(createUser, "User");
                var token = _jwtHandler.GetToken(createUser.Email, createUser.Id, role.Name);
                var currentUserDto = new UserDto();
                currentUserDto.Username = createUser.UserName;
                currentUserDto.Email = createUser.Email;
                return Ok(new { Token=token, User=currentUserDto});
            }
            else
            {
                throw new Exception("Email already in use");
            }
           


        }
    }
}
