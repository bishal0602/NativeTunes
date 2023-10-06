using NativeTunes.Application.Contracts.Persistence;
using NativeTunes.Application.Extensions;
using NativeTunes.Domain.PodcastAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Podcasts.Command.CreatePodcast
{
    public class CreatePodcastCommandHandler : IRequestHandler<CreatePodcastCommand, Result<Podcast, Error>>
    {
        private readonly IPodcastRepository _podcastRepository;
        private readonly IStorageService _storageService;

        public CreatePodcastCommandHandler(IPodcastRepository podcastRepository, IStorageService storageService)
        {
            _podcastRepository = podcastRepository;
            _storageService = storageService;
        }
        public async Task<Result<Podcast, Error>> Handle(CreatePodcastCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await request.ValidateAsync(new CreatePodcastCommandValidator());
            if (validationResult.IsFailure)
                return validationResult.Error;


            // uploading cover image
            var coverImageResult = await _storageService.UploadFileAsync("covers", request.CoverImage);
            if (coverImageResult.IsFailure)
            {
                return new BadRequestError(coverImageResult.ErrorMessage);
            }
            // uploading podcast file
            var podcastFileResult = await _storageService.UploadFileAsync("podcasts", request.AudioFile);
            if (podcastFileResult.IsFailure)
            {
                await _storageService.DeleteAsync(coverImageResult.Url); // removing cover image
                return new BadRequestError(podcastFileResult.ErrorMessage);
            }

            var podcast = Podcast.CreateNew(request.Title, request.Description, request.Language, coverImageResult.Url, podcastFileResult.Url);

            _podcastRepository.AddPodcast(podcast);
            await _podcastRepository.SaveChangesAsync();

            return podcast;
        }
    }
}
