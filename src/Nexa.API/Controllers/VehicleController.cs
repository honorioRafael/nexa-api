using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleController : BaseController<Vehicle, IVehicleService>
{

    public VehicleController(IVehicleService vehicleService) : base(vehicleService)
    {
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null) return NotFound();
        return Ok(new VehicleDto(entity.Id, entity.LicensePlate, entity.VehicleModelId, entity.ChassisNumber, entity.Mileage, entity.Status));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var entities = await _service.GetAllAsync();
        return Ok(entities.Select(e => new VehicleDto(e.Id, e.LicensePlate, e.VehicleModelId, e.ChassisNumber, e.Mileage, e.Status)));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateVehicleDto dto)
    {
        var entity = new Vehicle
        {
            LicensePlate = dto.LicensePlate,
            VehicleModelId = dto.VehicleModelId,
            ChassisNumber = dto.ChassisNumber,
            Mileage = dto.Mileage,
            Status = dto.Status
        };
        await _service.AddAsync(entity);
        return CreatedAtAction(nameof(Get), new { id = entity.Id }, new VehicleDto(entity.Id, entity.LicensePlate, entity.VehicleModelId, entity.ChassisNumber, entity.Mileage, entity.Status));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, UpdateVehicleDto dto)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null) return NotFound();

        entity.LicensePlate = dto.LicensePlate;
        entity.Mileage = dto.Mileage;
        entity.Status = dto.Status;

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
