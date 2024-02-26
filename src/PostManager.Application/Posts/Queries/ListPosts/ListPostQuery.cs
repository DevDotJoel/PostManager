using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;
using PostManager.Application.Common.Models.Post;

namespace PostManager.Application.Posts.Queries.ListPosts
{
    public record ListPostQuery() : IRequest<ErrorOr<List<PostModel>>>;
}