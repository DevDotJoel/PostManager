using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostManager.Api.Entities
{
    public class User : IdentityUser<int>
    {
        public ICollection<Post>? Posts { get; set; }
        public ICollection<PostComment>? Comments { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


    }
}