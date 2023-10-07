using NativeTunes.Application.Contracts.Persistence.Forum;
using NativeTunes.Domain.ForumAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Forum.Query.GetPostList
{
    public class GetPostListQueryHandler : IRequestHandler<GetPostListQuery, Result<IEnumerable<Post>, Error>>
    {
        private readonly IForumRepository _forumRepository;

        public GetPostListQueryHandler(IForumRepository forumRepository)
        {
            _forumRepository = forumRepository;
        }
        public async Task<Result<IEnumerable<Post>, Error>> Handle(GetPostListQuery request, CancellationToken cancellationToken)
        {
            var posts = await _forumRepository.GetPostListAsync();
            return posts.ToList();
        }
    }
}
