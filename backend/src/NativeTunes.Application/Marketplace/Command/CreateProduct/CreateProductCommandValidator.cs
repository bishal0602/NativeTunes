using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Marketplace.Command.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.Price).GreaterThan(0);
            RuleFor(p => p.ImageFile).NotNull();
            // TODO: Add further validations as needed
        }
    }

}
