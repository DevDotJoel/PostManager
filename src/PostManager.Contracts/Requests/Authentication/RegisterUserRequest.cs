using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Contracts.Requests.Authentication
{
   public record RegisterUserRequest
   (
     string Email,
     string Username,
     string Password
   );
}
