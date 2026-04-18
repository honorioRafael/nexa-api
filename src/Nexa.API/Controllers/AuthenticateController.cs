using Microsoft.AspNetCore.Mvc;
using Nexa.Application.DTOs.Authenticate;
using Nexa.Application.Interfaces.Services;

namespace Nexa.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticateController(IAuthenticateService service) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Authenticate(InputAuthenticateDto inputAuthenticateDTO)
    {
        try
        {
            return Ok(await service.Authenticate(inputAuthenticateDTO));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
