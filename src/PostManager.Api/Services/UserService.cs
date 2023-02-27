using PostManager.Api.Contracts;
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
        public int GetUserId()
        {
            var userId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Convert.ToInt16(userId);
        }
    }
}
