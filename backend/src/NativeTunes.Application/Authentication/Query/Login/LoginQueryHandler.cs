using Microsoft.AspNetCore.Identity;
using NativeTunes.Application.Authentication.Common;
using NativeTunes.Application.Contracts.Persistence;
using NativeTunes.Application.Contracts.Persistence.Users;
using NativeTunes.Application.Contracts.Services;
using NativeTunes.Application.Extensions;
using NativeTunes.Domain.UserAggregate;
using NativeTunes.Shared.Errors.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Authentication.Query.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, Result<AuthenticationResponse, Error>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IPasswordHasher<User> _passwordHasher;

        public LoginQueryHandler(IUserRepository userRepository, IJwtGenerator jwtGenerator, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _jwtGenerator = jwtGenerator;
            _passwordHasher = passwordHasher;
        }
        public async Task<Result<AuthenticationResponse, Error>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            Result<bool, ValidationError> validationResult = await request.ValidateAsync(new LoginQueryValidator(), cancellationToken);
            if (validationResult.IsFailure)
                return validationResult.Error;

            User? user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user is null)
                return new InvalidCredentialsError("Invalid email or password");

            PasswordVerificationResult passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, request.Password);

            if (passwordVerificationResult == PasswordVerificationResult.Failed)
                return new InvalidCredentialsError("Invalid email or password");

            string token = _jwtGenerator.CreateToken(user);

            return new AuthenticationResponse(user, token);
        }
    }
}
