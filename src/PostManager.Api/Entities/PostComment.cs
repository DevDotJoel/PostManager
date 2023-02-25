using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PostManager.Api.Common.Interfaces;
using PostManager.Api.Common.Models;

namespace PostManager.Api.Entities
{
    public class PostComment : Audit, IBaseUser
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}