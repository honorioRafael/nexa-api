using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

[Route("api/housing-allocations")]
public class HousingAllocationController : BaseController<HousingAllocation, IHousingAllocationService, HousingAllocationDto, CreateHousingAllocationDto, UpdateHousingAllocationDto>
{
    public HousingAllocationController(IHousingAllocationService housingAllocationService) : base(housingAllocationService) { }

    [HttpGet("housing/{housingId}")]
    public async Task<IActionResult> GetByHousingId(long housingId, CancellationToken cancellationToken)
    {
        var result = await _service.GetByHousingIdAsync(housingId, cancellationToken);
        return Ok(result);
    }
}
