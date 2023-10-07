using NativeTunes.Domain.ForumAggregate;

namespace NativeTunes.Application.Forum.Query.GetPostDetail
{
    public record GetPostDetailQuery(string Id) : IRequest<Result<Post, Error>>
    {
    }
}
