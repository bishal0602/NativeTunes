using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NativeTunes.API.Models.Podcasts;
using NativeTunes.Application.Podcasts.Command.CreatePodcast;
using NativeTunes.Application.Podcasts.Command.DeletePodcast;
using NativeTunes.Application.Podcasts.Query.GetPodcastDetail;
using NativeTunes.Application.Podcasts.Query.GetPodcastList;
using NativeTunes.Domain.PodcastAggregate;

namespace NativeTunes.API.Controllers
{
    [Route("api/podcasts")]
    public class PodcastsController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PodcastsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePodcast([FromForm] PodcastForCreationDto podcast)
        {
            var command = new CreatePodcastCommand(podcast.Title, podcast.Description, podcast.AudioFile, podcast.CoverImage, podcast.Language);
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return Problem(result.Error);

            return Ok(result.Value);
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<PodcastDto>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPodcasts()
        {
            var query = new GetPodcastListQuery();
            var result = await _mediator.Send(query);
            if (result.IsFailure)
                return Problem(result.Error);

            List<PodcastDto> podcasts = _mapper.Map<List<PodcastDto>>(result.Value);
            return Ok(podcasts);
        }
        [HttpGet("{podcastId}")]
        [ProducesResponseType(typeof(PodcastDto), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPodcastDetail([FromRoute] string podcastId)
        {
            var query = new GetPodcastDetailQuery(podcastId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
                return Problem(result.Error);

            PodcastDto podcast = _mapper.Map<PodcastDto>(result.Value);
            return Ok(podcast);
        }
        [HttpDelete("{podcastId}")]
        public async Task<IActionResult> DeletePodcast([FromRoute] string podcastId)
        {
            var command = new DeletePodcastCommand(podcastId);
            var result = await _mediator.Send(command);
            if (result.IsFailure)
                return Problem(result.Error);

            return NoContent();
        }
    }
}
