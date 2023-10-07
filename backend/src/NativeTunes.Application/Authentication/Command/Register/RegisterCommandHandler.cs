using Microsoft.AspNetCore.Identity;
using NativeTunes.Application.Authentication.Common;
using NativeTunes.Application.Contracts.Persistence.Users;
using NativeTunes.Application.Contracts.Persistence;
using NativeTunes.Application.Contracts.Services;
using NativeTunes.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NativeTunes.Application.Extensions;
using NativeTunes.Shared.Errors.Authentication;

namespace NativeTunes.Application.Authentication.Command.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<AuthenticationResponse, Error>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IStorageService _storageService;
        private readonly IPasswordHasher<User> _passwordHasher;

        public RegisterCommandHandler(IUserRepository userRepository, IJwtGenerator jwtGenerator, IStorageService storageService, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _jwtGenerator = jwtGenerator;
            _storageService = storageService;
            _passwordHasher = passwordHasher;
        }
        public async Task<Result<AuthenticationResponse, Error>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            Result<bool, ValidationError> validationResult = await request.ValidateAsync(new RegisterCommandValidator(), cancellationToken);
            if (validationResult.IsFailure)
                return validationResult.Error;


            if ((await _userRepository.GetUserByEmailAsync(request.Email)) is not null)
            {
                return new EmailAlreadyInUseError();
            }
            FileUploadInfo? profilePicture = null;
            if (request.ProfilePicture is not null)
            {
                profilePicture = await _storageService.UploadFileAsync("profiles", request.ProfilePicture);
            }
            User user = User.CreateNew(request.FirstName, request.LastName, request.Email, null, profilePicture?.Url);

            string hashedPassword = _passwordHasher.HashPassword(user, request.Password);
            user.UpdatePassword(hashedPassword);

            _userRepository.AddUser(user);
            await _userRepository.SaveChangesAsync();

            string token = _jwtGenerator.CreateToken(user);
            return new AuthenticationResponse(user, token);
        }
    }
}
