using MediatR;
using PostManager.Application.Common.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Application.Posts.Commands.CreatePost
{
    public record CreatePostCommand 
    (
        string Title,
        string Content    
     )
        :IRequest<PostModel>;
}
