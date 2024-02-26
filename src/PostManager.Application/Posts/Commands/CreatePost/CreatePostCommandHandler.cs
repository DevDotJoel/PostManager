using ErrorOr;
using MapsterMapper;
using MediatR;
using PostManager.Application.Common.Contracts;
using PostManager.Application.Common.Models.Post;
using PostManager.Application.Common.Repositories;
using PostManager.Domain.Aggregates.PostAggregate;
using PostManager.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Application.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, ErrorOr<PostModel>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public CreatePostCommandHandler(IPostRepository postRepository, IUserService userService, IMapper mapper)
        {
            _postRepository = postRepository;
            _userService = userService;
            _mapper = mapper;

        }
        public async Task<ErrorOr<PostModel>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var userId = UserId.Create(_userService.GetUserId());
            var post = Post.Create(request.Title, request.Content, userId);
            await _postRepository.AddAsync(post);
            return _mapper.Map<PostModel>(post);
        }
    }
}
