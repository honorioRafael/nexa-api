using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleTripController : BaseController<VehicleTrip, IVehicleTripService>
{

    public VehicleTripController(IVehicleTripService vehicleTripService) : base(vehicleTripService)
    {
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null) return NotFound();
        return Ok(new VehicleTripDto(entity.Id, entity.VehicleAllocationId, entity.Origin, entity.Destination, entity.StartDate, entity.EndDate, entity.Status, entity.Distance));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var entities = await _service.GetAllAsync();
        return Ok(entities.Select(e => new VehicleTripDto(e.Id, e.VehicleAllocationId, e.Origin, e.Destination, e.StartDate, e.EndDate, e.Status, e.Distance)));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateVehicleTripDto dto)
    {
        var entity = new VehicleTrip
        {
            VehicleAllocationId = dto.VehicleAllocationId,
            Origin = dto.Origin,
            Destination = dto.Destination,
            StartDate = dto.StartDate,
            Status = Domain.Enums.VehicleTripStatus.AwaitingDriver,
            Distance = 0
        };
        await _service.AddAsync(entity);
        return CreatedAtAction(nameof(Get), new { id = entity.Id }, new VehicleTripDto(entity.Id, entity.VehicleAllocationId, entity.Origin, entity.Destination, entity.StartDate, entity.EndDate, entity.Status, entity.Distance));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, UpdateVehicleTripDto dto)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null) return NotFound();

        entity.EndDate = dto.EndDate;
        entity.Status = dto.Status;
        entity.Distance = dto.Distance;

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
