using NativeTunes.Domain.Common.Interfaces;
using NativeTunes.Domain.PodcastAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Domain.MarketplaceAggregate.ValueObjects
{
    public record ProductId : IValueObject
    {
        public Guid Value { get; private set; }
        private ProductId() { }
        private ProductId(Guid value)
        {
            Value = value;
        }
        public static ProductId Create(Guid value) => new(value);
        public static ProductId CreateNew() => new(Guid.NewGuid());
    }
}
