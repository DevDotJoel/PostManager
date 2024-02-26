using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Application.Common.Models.Post
{
    public record PostModel
     (
         string Id,
         string Title,
         string Content
     );
}
