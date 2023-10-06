using NativeTunes.Application.Contracts.Persistence;
using NativeTunes.Domain.PodcastAggregate;
using NativeTunes.Domain.PodcastAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Podcasts.Query.GetPodcastDetail
{
    public class GetPodcastDetailQueryHandler : IRequestHandler<GetPodcastDetailQuery, Result<Podcast, Error>>
    {
        private readonly IPodcastRepository _podcastRepository;

        public GetPodcastDetailQueryHandler(IPodcastRepository podcastRepository)
        {
            _podcastRepository = podcastRepository;
        }
        public async Task<Result<Podcast, Error>> Handle(GetPodcastDetailQuery request, CancellationToken cancellationToken)
        {

            if (!Guid.TryParse(request.Id, out var idInGuid))
            {
                return new BadRequestError($"Invalid id: {request.Id}");
            }
            var podcastId = PodcastId.Create(idInGuid);
            var podcast = await _podcastRepository.GetPodcastByIdAsync(podcastId);
            if (podcast is null)
                return new NotFoundError($"Podcast with Id {request.Id} not found");
            return podcast;
        }
    }
}
