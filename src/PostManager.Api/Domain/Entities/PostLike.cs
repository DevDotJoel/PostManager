using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostManager.Api.Domain.Common.Models;

namespace PostManager.Api.Domain.Entities
{
    public class PostLike
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}