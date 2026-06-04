using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Enums;

namespace Nexa.API.Controllers;

[ApiController]
[Authorize]
[Route("api/movements")]
public class MovementController(IMovementService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetDashboard(
        [FromQuery] string? search,
        [FromQuery] List<MovementType>? types,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var result = await service.GetDashboardAsync(search, types, page, pageSize, cancellationToken);
        return Ok(result);
    }
}
