using PostManager.Domain.Aggregates.PostAggregate;
using PostManager.Domain.Aggregates.PostAggregate.ValueObjects;

namespace PostManager.Application.Common.Repositories
{
    public interface IPostRepository:IBaseRepository<PostId,Post>
    {
    }
}
