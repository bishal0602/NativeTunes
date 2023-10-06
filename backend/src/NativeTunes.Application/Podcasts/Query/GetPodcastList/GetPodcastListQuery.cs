using NativeTunes.Domain.PodcastAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Podcasts.Query.GetPodcastList
{
    public class GetPodcastListQuery : IRequest<Result<IEnumerable<Podcast>, Error>>
    {
    }
}
