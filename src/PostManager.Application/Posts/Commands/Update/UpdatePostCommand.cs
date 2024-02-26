using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;
using PostManager.Application.Common.Models.Post;

namespace PostManager.Application.Posts.Commands.Update
{
    public record UpdatePostCommand(
        Guid Id,
        string Title,
        string Content
    ) : IRequest<ErrorOr<PostModel>>;
}