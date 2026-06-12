using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.Interfaces.Services;

namespace Nexa.API.Controllers;

[Authorize]
[Route("api/dashboard")]
public class DashboardController(IDashboardService dashboardService) : ApiController
{
    [HttpGet("occupancy-evolution")]
    public async Task<IActionResult> GetOccupancyEvolution(
        [FromQuery] DateTime? startDate,
        [FromQuery] DateTime? endDate,
        CancellationToken cancellationToken)
    {
        var data = await dashboardService.GetOccupancyEvolutionAsync(startDate, endDate, cancellationToken);
        return Ok(data);
    }

    [HttpGet("vehicle-ranking")]
    public async Task<IActionResult> GetVehicleRanking(
        [FromQuery] DateTime? startDate,
        [FromQuery] DateTime? endDate,
        CancellationToken cancellationToken)
    {
        var data = await dashboardService.GetVehicleRankingAsync(startDate, endDate, cancellationToken);
        return Ok(data);
    }
}
