using NativeTunes.Application.Contracts.Persistence.Forum;
using NativeTunes.Application.Extensions;
using NativeTunes.Domain.ForumAggregate;

namespace NativeTunes.Application.Forum.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Result<Post, Error>>
    {
        private readonly IForumRepository _forumRepository;

        public CreatePostCommandHandler(IForumRepository forumRepository)
        {
            _forumRepository = forumRepository;
        }
        public async Task<Result<Post, Error>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await request.ValidateAsync(new CreatePostCommandValidator(), cancellationToken);
            if (validationResult.IsFailure)
                return validationResult.Error;

            var post = Post.CreateNew(request.Title, request.Description);

            _forumRepository.AddPost(post);
            await _forumRepository.SaveChangesAsync();
            return post;
        }
    }
}
