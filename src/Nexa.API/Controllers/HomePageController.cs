using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;

namespace Nexa.API.Controllers;

[ApiController]
[Authorize]
[Route("api/home")]
public class HomePageController(IHomePageService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetHomePageData(CancellationToken cancellationToken)
    {
        var data = await service.GetHomePageData(cancellationToken);
        return Ok(data);
    }
}