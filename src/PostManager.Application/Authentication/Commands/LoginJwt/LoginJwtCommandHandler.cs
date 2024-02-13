using ErrorOr;
using MediatR;
using PostManager.Application.Common.Contracts;
using PostManager.Application.Common.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Application.Authentication.Commands.LoginJwt
{
    public class LoginJwtCommandHandler : IRequestHandler<LoginJwtCommand, ErrorOr<AuthenticationResultModel>>
    {
        private readonly IIdentityService _identityService;
        public LoginJwtCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
            
        }
        public async Task<ErrorOr<AuthenticationResultModel>> Handle(LoginJwtCommand request, CancellationToken cancellationToken)
        {
            var result= await _identityService.LoginJwt(request.Email,request.Password);
            return result;
        }
    }
}
