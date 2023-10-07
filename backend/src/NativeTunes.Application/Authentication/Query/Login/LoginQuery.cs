using NativeTunes.Application.Authentication.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Authentication.Query.Login
{
    public record LoginQuery(string Email, string Password) : IRequest<Result<AuthenticationResponse, Error>>
    {
    }
}
