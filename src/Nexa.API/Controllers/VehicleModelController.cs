using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleModelController : BaseController<VehicleModel, IVehicleModelService>
{

    public VehicleModelController(IVehicleModelService vehicleModelService) : base(vehicleModelService)
    {
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null) return NotFound();
        return Ok(new VehicleModelDto(entity.Id, entity.Manufacturer, entity.Type, entity.Year, entity.FuelType, entity.MaxCapacity));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var entities = await _service.GetAllAsync();
        return Ok(entities.Select(e => new VehicleModelDto(e.Id, e.Manufacturer, e.Type, e.Year, e.FuelType, e.MaxCapacity)));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateVehicleModelDto dto)
    {
        var entity = new VehicleModel
        {
            Manufacturer = dto.Manufacturer,
            Type = dto.Type,
            Year = dto.Year,
            FuelType = dto.FuelType,
            MaxCapacity = dto.MaxCapacity
        };
        await _service.AddAsync(entity);
        return CreatedAtAction(nameof(Get), new { id = entity.Id }, new VehicleModelDto(entity.Id, entity.Manufacturer, entity.Type, entity.Year, entity.FuelType, entity.MaxCapacity));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, UpdateVehicleModelDto dto)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null) return NotFound();

        entity.Manufacturer = dto.Manufacturer;
        entity.Type = dto.Type;
        entity.Year = dto.Year;
        entity.FuelType = dto.FuelType;
        entity.MaxCapacity = dto.MaxCapacity;

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
