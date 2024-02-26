using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using MapsterMapper;
using MediatR;
using PostManager.Application.Common.Models.Post;
using PostManager.Application.Common.Repositories;
using PostManager.Domain.Aggregates.PostAggregate;
using PostManager.Domain.Aggregates.PostAggregate.ValueObjects;

namespace PostManager.Application.Posts.Commands.Update
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, ErrorOr<PostModel>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public UpdatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;

        }
        public async Task<ErrorOr<PostModel>> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(PostId.Create(request.Id));
            if (post is null)
            {
                return Error.NotFound(description: "Post not found");
            }
            post.SetTitle(request.Title);
            post.SetContent(request.Content);
            await _postRepository.UpdateAsync(post);
            return _mapper.Map<PostModel>(post);
        }
    }
}