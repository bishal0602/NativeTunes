using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NativeTunes.API.Models.Forum;
using NativeTunes.Application.Forum.Commands.CreatePost;
using NativeTunes.Application.Forum.Query.GetPostDetail;
using NativeTunes.Application.Forum.Query.GetPostList;

namespace NativeTunes.API.Controllers
{
    [Route("api/forum")]
    public class ForumController : ApiControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ForumController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpGet("posts")]
        [ProducesResponseType(typeof(IEnumerable<PostDto>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPostsList()
        {
            var query = new GetPostListQuery();
            var result = await _mediator.Send(query);
            if (result.IsFailure)
                return Problem(result.Error);
            List<PostDto> postsList = _mapper.Map<List<PostDto>>(result.Value);
            return Ok(postsList);
        }
        [HttpGet("posts/{postId}", Name = "GetPostById")]
        [ProducesResponseType(typeof(PostDto), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPostDetail([FromRoute] string postId)
        {
            var query = new GetPostDetailQuery(postId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
                return Problem(result.Error);
            PostDto post = _mapper.Map<PostDto>(result.Value);
            return Ok(post);
        }
        [Authorize]
        [HttpPost("posts")]
        [ProducesResponseType(typeof(PostDto), statusCode: StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePost([FromBody] PostForCreation post)
        {
            var command = new CreatePostCommand(post.Title, post.Description);
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return Problem(result.Error);

            PostDto postToReturn = _mapper.Map<PostDto>(result.Value);
            return CreatedAtRoute("GetPostById", new { postId = postToReturn.Id }, postToReturn);
        }
    }
}
