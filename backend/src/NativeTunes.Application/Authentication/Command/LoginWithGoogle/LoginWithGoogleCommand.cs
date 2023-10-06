using NativeTunes.Application.Authentication.Common;

namespace NativeTunes.Application.Authentication.Command.LoginWithGoogle
{
    public record LoginWithGoogleCommand(string Token) : IRequest<Result<AuthenticationResponse, Error>>
    {
    }
}
