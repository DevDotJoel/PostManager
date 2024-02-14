using ErrorOr;
using MediatR;
using PostManager.Application.Common.Contracts;
using PostManager.Application.Common.Models.Authentication;
using PostManager.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Application.Users.Queries
{
    public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, ErrorOr<AuthUserModel>>
    {
        private readonly IUserService _userService;
        private readonly IIdentityService _identityService;
        public GetCurrentUserQueryHandler(IUserService userService, IIdentityService identityService)
        {
            _userService = userService;
            _identityService = identityService;
            
        }
        public async Task<ErrorOr<AuthUserModel>> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var userId = UserId.Create(_userService.GetUserId());
            var user = await _identityService.GetUserById(userId.Value.ToString());
            return user;
        }
    }
}
