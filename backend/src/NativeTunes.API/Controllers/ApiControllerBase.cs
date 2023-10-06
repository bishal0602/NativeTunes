using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NativeTunes.Shared.Errors;
using NativeTunes.Shared.Errors.General;

namespace NativeTunes.API.Controllers
{
    [ApiController]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    [ProducesResponseType(typeof(ProblemDetails), statusCode: StatusCodes.Status500InternalServerError)]
    public class ApiControllerBase : ControllerBase
    {
        protected IActionResult Problem(Error error)
        {
            return error switch
            {
                ValidationError validationError => ValidationProblem(validationError),
                _ => Problem(statusCode: error.StatusCode, type: error.ErrorType, detail: error.ErrorMessage)
            };
        }
        protected IActionResult ValidationProblem(ValidationError validationError)
        {
            var modelStateDictionary = new ModelStateDictionary();
            foreach (var error in validationError.ValidationErrorDictionary)
            {
                modelStateDictionary.AddModelError(error.Key, error.Value);
            }
            return ValidationProblem(modelStateDictionary: modelStateDictionary, type: validationError.ErrorType);
        }
    }
}
