using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostManager.Api.Common.Models
{
    public class Audit
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}