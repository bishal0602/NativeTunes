using Microsoft.AspNetCore.Http;

namespace NativeTunes.Shared.Errors.General
{
    public class BadRequestError : Error
    {
        protected BadRequestError(string errorType = nameof(BadRequestError), int statusCode = StatusCodes.Status400BadRequest, string? errorMessage = null) : base(errorType, statusCode, errorMessage)
        {
        }
        public BadRequestError(string errorMessage) : base(nameof(BadRequestError), StatusCodes.Status400BadRequest, errorMessage) { }
    }
}
