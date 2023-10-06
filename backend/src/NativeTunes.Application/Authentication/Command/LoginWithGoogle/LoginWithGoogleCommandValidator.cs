using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Authentication.Command.LoginWithGoogle
{
    public class LoginWithGoogleCommandValidator : AbstractValidator<LoginWithGoogleCommand>
    {
        public LoginWithGoogleCommandValidator()
        {
            RuleFor(x => x.Token).NotEmpty();
        }
    }
}
