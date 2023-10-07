using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NativeTunes.API.Models.Authentication;
using NativeTunes.Application.Authentication.Command.Register;
using NativeTunes.Application.Authentication.Query.Login;

namespace NativeTunes.API.Controllers
{
    [Route("api/auth")]
    public class AuthenticationController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost("login")]
        [ProducesResponseType(typeof(ValidationProblemDetails), statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(AuthResponse), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] LoginModel request)
        {
            var query = new LoginQuery(request.Email, request.Password);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
                return Problem(result.Error);

            AuthResponse authResponse = _mapper.Map<AuthResponse>(result.Value);
            return Ok(authResponse);
        }
        [HttpPost("register")]
        [ProducesResponseType(typeof(ValidationProblemDetails), statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(AuthResponse), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Register([FromForm] RegisterModel request)
        {
            var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password, request.ProfilePicture);
            var result = await _mediator.Send(command);
            if (result.IsFailure)
                return Problem(result.Error);

            AuthResponse authResponse = _mapper.Map<AuthResponse>(result.Value);
            return Ok(authResponse);
        }
    }
}
