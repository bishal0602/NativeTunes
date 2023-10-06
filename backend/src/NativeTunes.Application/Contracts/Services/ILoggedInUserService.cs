using NativeTunes.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Contracts.Services
{
    public interface ILoggedInUserService
    {
        UserId? UserId { get; }
    }
}
