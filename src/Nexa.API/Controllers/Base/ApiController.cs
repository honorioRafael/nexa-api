using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace Nexa.API.Controllers.Base;

[ApiController]
public abstract class ApiController : ControllerBase
{
    protected IActionResult HandleErrors(List<Error> errors)
    {
        var first = errors[0];

        var statusCode = first.Type switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
            ErrorType.Forbidden => StatusCodes.Status403Forbidden,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(title: first.Code, detail: first.Description, statusCode: statusCode);
    }
}
