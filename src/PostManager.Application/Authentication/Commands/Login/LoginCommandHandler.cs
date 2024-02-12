using MediatR;
using PostManager.Application.Common.Contracts;
using PostManager.Application.Common.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Application.Authentication.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthenticationResultModel>
    {
        private readonly IIdentityService _identityService;
        public LoginCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
            
        }
        public async Task<AuthenticationResultModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result= await _identityService.LoginJwt(request.Email,request.Password);
            return result;
        }
    }
}
