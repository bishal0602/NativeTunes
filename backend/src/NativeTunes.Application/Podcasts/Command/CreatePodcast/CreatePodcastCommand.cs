using Microsoft.AspNetCore.Http;
using NativeTunes.Domain.PodcastAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Podcasts.Command.CreatePodcast
{
    public record CreatePodcastCommand(string Title, string? Description, IFormFile AudioFile, IFormFile CoverImage, string Language) : IRequest<Result<Podcast, Error>>
    {
    }
}
