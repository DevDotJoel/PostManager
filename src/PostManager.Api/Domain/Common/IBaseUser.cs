using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostManager.Api.Domain.Common
{
    public interface IBaseUser
    {
        public int UserId { get; set; }

    }
}