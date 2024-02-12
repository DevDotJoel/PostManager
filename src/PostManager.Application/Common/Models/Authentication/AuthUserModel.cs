using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Application.Common.Models.Authentication
{
    public record AuthUserModel
    (
      string Id,
      string Username,
      string Email
    );
}
