using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleAllocationController : BaseController<VehicleAllocation, IVehicleAllocationService>
{

    public VehicleAllocationController(IVehicleAllocationService vehicleAllocationService) : base(vehicleAllocationService)
    {
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null) return NotFound();
        return Ok(new VehicleAllocationDto(entity.Id, entity.DriverId, entity.VehicleId, entity.StartDate, entity.EndDate));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var entities = await _service.GetAllAsync();
        return Ok(entities.Select(e => new VehicleAllocationDto(e.Id, e.DriverId, e.VehicleId, e.StartDate, e.EndDate)));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateVehicleAllocationDto dto)
    {
        var entity = new VehicleAllocation
        {
            DriverId = dto.DriverId,
            VehicleId = dto.VehicleId,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate
        };
        await _service.AddAsync(entity);
        return CreatedAtAction(nameof(Get), new { id = entity.Id }, new VehicleAllocationDto(entity.Id, entity.DriverId, entity.VehicleId, entity.StartDate, entity.EndDate));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, UpdateVehicleAllocationDto dto)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null) return NotFound();

        entity.EndDate = dto.EndDate;

        await _service.UpdateAsync(entity);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
