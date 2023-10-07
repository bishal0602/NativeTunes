using NativeTunes.Domain.Common;
using NativeTunes.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Domain.UserAggregate
{
    public class User : AggregateRoot<UserId>
    {
        public string FirstName { get; private set; }
        public string LastName { get; set; }
        public string Email { get; private set; }
        public string? Password { get; private set; } // nullable for oauth cases
        public string? ProfilePicture { get; private set; }
        private User() { }
        private User(UserId id, string firstName, string lastName, string email, string? password, string? profilePicture)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            ProfilePicture = profilePicture;
        }
        public static User CreateNew(string firstName, string lastName, string email, string? password, string? profilePicture) => new(UserId.CreateNew(), firstName, lastName, email, password, profilePicture);
        public static User Create(UserId id, string firstName, string lastName, string email, string? password, string? profilePicture) => new(id, firstName, lastName, email, password, profilePicture);
        public void UpdatePassword(string password)
        {
            Password = password;
        }
    }
}
