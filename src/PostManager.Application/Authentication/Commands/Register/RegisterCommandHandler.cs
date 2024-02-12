using MediatR;
using PostManager.Application.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand>
    {
        private readonly IIdentityService _identityService;
        public RegisterCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
            
        }
        public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
          await _identityService.Register(request.Email,request.Username,request.Password);
        }
    }
}
