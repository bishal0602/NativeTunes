using NativeTunes.Domain.ForumAggregate;

namespace NativeTunes.Application.Forum.Commands.CreatePost
{
    public record CreatePostCommand(string Title, string? Description) : IRequest<Result<Post, Error>>
    {
    }
}
