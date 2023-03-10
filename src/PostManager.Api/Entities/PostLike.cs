using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PostManager.Api.Entities
{
    public class PostLike
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        public virtual Post? Post { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }

    }
}