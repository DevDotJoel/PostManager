using ErrorOr;
using PostManager.Application.Common.Models.Authentication;
using PostManager.Application.Common.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Application.Common.Contracts
{
    public interface IIdentityService
    {
        Task<ErrorOr<AuthUserModel>> GetUserById(string id);
        Task<AuthenticationResultModel> LoginJwt(string email, string password);

        Task<bool> Register(string email,string username,string password);
    }
}
