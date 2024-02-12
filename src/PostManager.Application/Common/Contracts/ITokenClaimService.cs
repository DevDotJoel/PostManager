using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Application.Common.Contracts
{
    public interface ITokenClaimService
    {
        string GetToken(string email, string userId, List<string> currentClaims);
    }
}

