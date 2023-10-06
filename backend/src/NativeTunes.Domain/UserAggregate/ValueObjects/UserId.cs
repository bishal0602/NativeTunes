using NativeTunes.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Domain.UserAggregate.ValueObjects
{
    public record UserId : IValueObject
    {
        public Guid Value { get; private set; }
        private UserId() { }
        private UserId(Guid value)
        {
            Value = value;
        }
        public static UserId Create(Guid value) => new(value);
        public static UserId CreateNew() => new(Guid.NewGuid());
    }
}
