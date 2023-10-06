using NativeTunes.Application.Contracts.Persistence;
using NativeTunes.Domain.PodcastAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Podcasts.Command.DeletePodcast
{
    public class DeletePodcastCommandHandler : IRequestHandler<DeletePodcastCommand, Result<bool, Error>>
    {
        private readonly IPodcastRepository _podcastRepository;
        private readonly IStorageService _storageService;

        public DeletePodcastCommandHandler(IPodcastRepository podcastRepository, IStorageService storageService)
        {
            _podcastRepository = podcastRepository;
            _storageService = storageService;
        }
        public async Task<Result<bool, Error>> Handle(DeletePodcastCommand request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.Id, out var idInGuid))
            {
                return new BadRequestError($"Invalid id: {request.Id}");
            }
            var podcastId = PodcastId.Create(idInGuid);
            var podcast = await _podcastRepository.GetPodcastByIdAsync(podcastId);
            if (podcast is null)
                return new NotFoundError($"Podcast with Id {request.Id} not found");

            await _storageService.DeleteAsync(podcast.CoverImageUrl);
            await _storageService.DeleteAsync(podcast.PodcastUrl);

            _podcastRepository.DeletePodcast(podcast);
            await _podcastRepository.SaveChangesAsync();
            return true;
        }
    }
}
