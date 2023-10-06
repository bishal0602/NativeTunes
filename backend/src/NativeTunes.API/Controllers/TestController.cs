using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NativeTunes.API.Models.Authentication;
using NativeTunes.Application.Authentication.Command.LoginWithGoogle;

namespace NativeTunes.API.Controllers
{
    [Route("api/test")]
    public class TestController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TestController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(AuthResponse), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), statusCode: StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> TestMethod()
        {
            var command = new LoginWithGoogleCommand("randomtokengobrrrrrr");
            var result = await _mediator.Send(command);
            if (result.IsFailure)
                return Problem(result.Error);

            var response = _mapper.Map<AuthResponse>(result.Value);
            return Ok(response);
        }

        [HttpGet("protected")]
        [Authorize]
        [ProducesResponseType(typeof(string), statusCode: StatusCodes.Status200OK)]

        public IActionResult Protected()
        {
            return Ok("You are authorized");
        }
    }
}
