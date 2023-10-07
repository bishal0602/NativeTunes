using Microsoft.AspNetCore.Http;
using NativeTunes.Application.Authentication.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Authentication.Command.Register
{
    public record RegisterCommand(string FirstName, string LastName, string Email, string Password, IFormFile? ProfilePicture) : IRequest<Result<AuthenticationResponse, Error>>
    {
    }
}
