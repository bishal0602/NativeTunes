using NativeTunes.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Domain.ForumAggregate.ValueObjects
{
    public record PostId : IValueObject
    {
        public Guid Value { get; private set; }
        private PostId() { }
        private PostId(Guid value)
        {
            Value = value;
        }
        public static PostId CreateNew() => new(Guid.NewGuid());
        public static PostId Create(Guid value) => new(value);

    }
}
