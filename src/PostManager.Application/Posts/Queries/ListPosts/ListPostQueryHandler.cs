using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using MapsterMapper;
using MediatR;
using PostManager.Application.Common.Models.Post;
using PostManager.Application.Common.Repositories;

namespace PostManager.Application.Posts.Queries.ListPosts
{
    public class ListPostQueryHandler : IRequestHandler<ListPostQuery, ErrorOr<List<PostModel>>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public ListPostQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;

        }
        public async Task<ErrorOr<List<PostModel>>> Handle(ListPostQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<PostModel>>(await _postRepository.GetAllAsync());
        }
    }
}