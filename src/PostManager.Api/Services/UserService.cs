using PostManager.Application.Common.Contracts;
using PostManager.Infrastructure.Persistance.Identity;
using System.Security.Claims;

namespace PostManager.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContext;
        public UserService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public string GetUserEmail()
        {
           var email = _httpContext.HttpContext.User?.FindFirst(ClaimTypes.Email).Value;
            return email;
        }

        public Guid GetUserId()
        {
            var userId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Guid.Parse(userId);
        }
    }
}
