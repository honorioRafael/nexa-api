using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs.Authenticate;
using Nexa.Application.Interfaces.Services;

namespace Nexa.API.Controllers;

[Route("api/auth")]
public class AuthenticateController(IAuthenticateService service) : ApiController
{
    [HttpPost("login")]
    public async Task<IActionResult> Authenticate(InputAuthenticateDto inputAuthenticateDTO)
    {
        var result = await service.Authenticate(inputAuthenticateDTO);
        return result.Match(
            value => Ok(value),
            HandleErrors);
    }
}
