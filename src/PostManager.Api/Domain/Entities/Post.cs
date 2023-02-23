using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostManager.Api.Domain.Common.Models;
using System.ComponentModel.DataAnnotations;
namespace PostManager.Api.Domain.Entities
{
    public class Post : Audit, IBaseUser
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }

    }
}