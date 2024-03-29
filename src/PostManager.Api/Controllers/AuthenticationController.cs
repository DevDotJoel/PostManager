﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostManager.Application.Authentication.Commands.LoginJwt;
using PostManager.Application.Authentication.Commands.Register;
using PostManager.Contracts.Requests.Authentication;

namespace PostManager.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class AuthenticationController : ApiController
    {
       private ISender _mediator;

        public AuthenticationController(ISender mediator)
        {
            _mediator = mediator;
            
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest registerUserRequest)
        {
            var command= new RegisterCommand(registerUserRequest.Username,registerUserRequest.Email,registerUserRequest.Password);
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest loginUserRequest)
        {
            var command = new LoginJwtCommand( loginUserRequest.Email, loginUserRequest.Password);            
            return Ok(await _mediator.Send(command));
        }
    }
}
