using NativeTunes.Application.Contracts.Persistence.Forum;
using NativeTunes.Domain.ForumAggregate.ValueObjects;
using NativeTunes.Domain.ForumAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NativeTunes.Infrastructure.Persistence.Repositories.Forum
{
    public class ForumRepository : IForumRepository
    {
        private readonly NativeTunesDbContext _context;

        public ForumRepository(NativeTunesDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Post>> GetPostListAsync()
        {
            return await _context.Posts.Include(p => p.CreatedBy).ToListAsync();
        }

        public async Task<Post?> GetPostByIdAsync(PostId postId)
        {
            return await _context.Posts.Include(p => p.CreatedBy).FirstOrDefaultAsync(p => p.Id == postId);
        }

        public void AddPost(Post post)
        {
            _context.Posts.Add(post);
        }

        public void DeletePost(Post post)
        {
            _context.Posts.Remove(post);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
