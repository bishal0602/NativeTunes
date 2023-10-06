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
        private User() { }
        private User(UserId id)
        {
            Id = id;
        }
        public static User CreateNew() => new(UserId.CreateNew());
        public static User Create(UserId id) => new(id);
    }
}
