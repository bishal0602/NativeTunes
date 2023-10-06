using NativeTunes.Application.Contracts.Persistence;
using NativeTunes.Domain.PodcastAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Podcasts.Query.GetPodcastList
{
    public class GetPodcastListQueryHandler : IRequestHandler<GetPodcastListQuery, Result<IEnumerable<Podcast>, Error>>
    {
        private readonly IPodcastRepository _podcastRepository;

        public GetPodcastListQueryHandler(IPodcastRepository podcastRepository)
        {
            _podcastRepository = podcastRepository;
        }

        async Task<Result<IEnumerable<Podcast>, Error>> IRequestHandler<GetPodcastListQuery, Result<IEnumerable<Podcast>, Error>>.Handle(GetPodcastListQuery request, CancellationToken cancellationToken)
        {
            var podcasts = await _podcastRepository.GetPodcastListAsync();
            return podcasts.ToList();
        }
    }
}
