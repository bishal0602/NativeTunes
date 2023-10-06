using CSharpFunctionalExtensions;
using MediatR;
using NativeTunes.Application.Authentication.Common;
using NativeTunes.Application.Contracts.Services;
using NativeTunes.Application.Extensions;
using NativeTunes.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Authentication.Command.LoginWithGoogle
{
    public class LoginWithGoogleCommandHandler : IRequestHandler<LoginWithGoogleCommand, Result<AuthenticationResponse, Error>>
    {
        private readonly IJwtGenerator _jwtGenerator;

        public LoginWithGoogleCommandHandler(IJwtGenerator jwtGenerator)
        {
            _jwtGenerator = jwtGenerator;
        }
        public async Task<Result<AuthenticationResponse, Error>> Handle(LoginWithGoogleCommand request, CancellationToken cancellationToken)
        {
            Result<bool, ValidationError> validationResult = await request.ValidateAsync(new LoginWithGoogleCommandValidator(), cancellationToken);
            if (validationResult.IsFailure)
                return validationResult.Error;

            // TODO: Implement login with google

            User user1 = User.CreateNew();
            var token = _jwtGenerator.CreateToken(user1);
            return new AuthenticationResponse(user1, token);

        }
    }
}
