using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Contracts.Requests.Post
{
    public record CreatePostRequest
    (
        string Title,
        string Content    
    );
}
