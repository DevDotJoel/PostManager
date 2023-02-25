using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using PostManager.Api.Common.Models;
using PostManager.Api.Common.Interfaces;

namespace PostManager.Api.Entities
{
    public class Post : Audit, IBaseUser
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public ICollection<PostContent>? PostContents { get; set; }
        public ICollection<PostComment>? PostComments { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}