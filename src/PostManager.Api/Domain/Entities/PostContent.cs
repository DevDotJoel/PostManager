using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PostManager.Api.Domain.Entities
{
    public class PostContent
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        public int ContentId { get; set; }
        public Post Post { get; set; }
        public Storage Storage { get; set; }
    }
}