using NativeTunes.Domain.UserAggregate.ValueObjects;
using NativeTunes.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Contracts.Persistence.Users
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void DeleteUser(User user);
        Task<User?> GetUserByIdAsync(UserId userId);
        Task<User?> GetUserByEmailAsync(string email);
        Task<IEnumerable<User>> GetUserListAsync();
        Task<bool> SaveChangesAsync();
    }
}
