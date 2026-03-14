using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleMaintenanceController : BaseController<VehicleMaintenance, IVehicleMaintenanceService>
{

    public VehicleMaintenanceController(IVehicleMaintenanceService vehicleMaintenanceService) : base(vehicleMaintenanceService)
    {
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null) return NotFound();
        return Ok(new VehicleMaintenanceDto(entity.Id, entity.VehicleId, entity.Description, entity.StartDate, entity.EndDate, entity.Cost));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var entities = await _service.GetAllAsync();
        return Ok(entities.Select(e => new VehicleMaintenanceDto(e.Id, e.VehicleId, e.Description, e.StartDate, e.EndDate, e.Cost)));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateVehicleMaintenanceDto dto)
    {
        var entity = new VehicleMaintenance
        {
            VehicleId = dto.VehicleId,
            Description = dto.Description,
            StartDate = dto.StartDate,
            Cost = dto.Cost
        };
        await _service.AddAsync(entity);
        return CreatedAtAction(nameof(Get), new { id = entity.Id }, new VehicleMaintenanceDto(entity.Id, entity.VehicleId, entity.Description, entity.StartDate, entity.EndDate, entity.Cost));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, UpdateVehicleMaintenanceDto dto)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null) return NotFound();

        entity.Description = dto.Description;
        entity.EndDate = dto.EndDate;
        entity.Cost = dto.Cost;

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
