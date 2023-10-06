using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Podcasts.Command.CreatePodcast
{
    public class CreatePodcastCommandValidator : AbstractValidator<CreatePodcastCommand>
    {
        public CreatePodcastCommandValidator()
        {
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.AudioFile).NotNull();
            RuleFor(p => p.CoverImage).NotNull();
            RuleFor(p => p.Language).NotEmpty();
            //RuleFor(p => p.Description).NotEmpty().When(p => p.Description != null);
            // TODO: Further validations
        }
    }
}
