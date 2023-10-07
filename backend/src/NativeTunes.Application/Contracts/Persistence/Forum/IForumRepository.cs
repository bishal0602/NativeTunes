using NativeTunes.Domain.ForumAggregate.ValueObjects;
using NativeTunes.Domain.ForumAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Contracts.Persistence.Forum
{
    public interface IForumRepository
    {
        void AddPost(Post post);
        void DeletePost(Post post);
        Task<Post?> GetPostByIdAsync(PostId postId);
        Task<IEnumerable<Post>> GetPostListAsync();
        Task<bool> SaveChangesAsync();
    }
}
