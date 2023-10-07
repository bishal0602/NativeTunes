using Microsoft.EntityFrameworkCore;
using NativeTunes.Application.Contracts.Persistence.Users;
using NativeTunes.Domain.UserAggregate.ValueObjects;
using NativeTunes.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Infrastructure.Persistence.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly NativeTunesDbContext _context;

        public UserRepository(NativeTunesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUserListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(UserId userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }

}
