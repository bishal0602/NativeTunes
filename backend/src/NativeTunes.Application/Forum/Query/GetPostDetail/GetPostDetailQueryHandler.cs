using NativeTunes.Application.Contracts.Persistence.Forum;
using NativeTunes.Domain.ForumAggregate;
using NativeTunes.Domain.ForumAggregate.ValueObjects;

namespace NativeTunes.Application.Forum.Query.GetPostDetail
{
    public class GetPostDetailQueryHandler : IRequestHandler<GetPostDetailQuery, Result<Post, Error>>
    {
        private readonly IForumRepository _forumRepository;

        public GetPostDetailQueryHandler(IForumRepository forumRepository)
        {
            _forumRepository = forumRepository;
        }

        public async Task<Result<Post, Error>> Handle(GetPostDetailQuery request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.Id, out var idInGuid))
            {
                return new BadRequestError($"Invalid id: {request.Id}");
            }
            var postId = PostId.Create(idInGuid);
            var post = await _forumRepository.GetPostByIdAsync(postId);
            if (post is null)
                return new NotFoundError($"Post with Id {request.Id} not found");
            return post;
        }
    }
}
