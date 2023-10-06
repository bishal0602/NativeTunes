using NativeTunes.Domain.Common.Interfaces;
using NativeTunes.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Domain.PodcastAggregate.ValueObjects
{
    public record PodcastId : IValueObject
    {
        public Guid Value { get; private set; }
        private PodcastId() { }
        private PodcastId(Guid value)
        {
            Value = value;
        }
        public static PodcastId Create(Guid value) => new(value);
        public static PodcastId CreateNew() => new(Guid.NewGuid());
    }
}
