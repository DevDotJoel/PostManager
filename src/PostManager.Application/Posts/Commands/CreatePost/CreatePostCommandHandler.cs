using ErrorOr;
using MediatR;
using PostManager.Application.Common.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Application.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, ErrorOr<PostModel>>
    {
        public CreatePostCommandHandler()
        {

        }
        public Task<ErrorOr<PostModel>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
