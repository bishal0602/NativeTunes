using NativeTunes.Domain.Common.Interfaces;
using NativeTunes.Domain.UserAggregate.ValueObjects;
using NativeTunes.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Domain.Common
{
    public abstract class AuditableAggregate<TId> : AggregateRoot<TId>, IAuditable where TId : notnull
    {
        public User? CreatedBy { get; set; }
        public UserId? CreatedByUserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public User? LastModifiedBy { get; set; }
        public UserId? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
