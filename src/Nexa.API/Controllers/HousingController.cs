using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

[Route("api/housings")]
public class HousingController : BaseController<Housing, IHousingService, HousingDto, CreateHousingDto, UpdateHousingDto>
{
    public HousingController(IHousingService housingService) : base(housingService) { }

    [HttpGet("{id}")]
    public override async Task<IActionResult> Get(long id, CancellationToken cancellationToken)
    {
        var dto = await _service.GetByIdWithOccupancyAsync(id, cancellationToken);
        if (dto is null) return NotFound();
        return Ok(dto);
    }

    [HttpGet]
    public override async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var dtos = await _service.GetAllWithOccupancyAsync(cancellationToken);
        return Ok(dtos);
    }
}
