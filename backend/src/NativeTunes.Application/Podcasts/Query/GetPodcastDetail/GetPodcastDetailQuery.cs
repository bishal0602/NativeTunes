using NativeTunes.Domain.PodcastAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Podcasts.Query.GetPodcastDetail
{
    public record GetPodcastDetailQuery(string Id) : IRequest<Result<Podcast, Error>>
    {
    }
}
