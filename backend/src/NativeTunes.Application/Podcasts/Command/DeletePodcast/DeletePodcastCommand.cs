using NativeTunes.Domain.PodcastAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Podcasts.Command.DeletePodcast
{
    public record DeletePodcastCommand(string Id) : IRequest<Result<bool, Error>>
    {
    }
}
