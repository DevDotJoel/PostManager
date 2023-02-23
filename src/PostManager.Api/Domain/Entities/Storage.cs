using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PostManager.Api.Domain.Entities
{
    public class Storage
    {
        [Key]
        public int Id { get; set; }
        public string FilePath { get; set; }

    }
}