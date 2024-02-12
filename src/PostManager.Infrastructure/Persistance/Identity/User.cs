using Microsoft.AspNetCore.Identity;
using PostManager.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Infrastructure.Persistance.Identity
{
    public class User:IdentityUser<Guid>
    {

    }
}
