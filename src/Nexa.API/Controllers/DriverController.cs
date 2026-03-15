using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DriverController : BaseController<Driver, IDriverService>
{
    public DriverController(IDriverService driverService) : base(driverService) { }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null) return NotFound();
        return Ok(new DriverDto(entity.Id, entity.UserId, entity.LicenseNumber, entity.LicenseExpiration, entity.LicenseType, entity.VehicleId));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var entities = await _service.GetAllAsync();
        return Ok(entities.Select(e => new DriverDto(e.Id, e.UserId, e.LicenseNumber, e.LicenseExpiration, e.LicenseType, e.VehicleId)));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDriverDto dto)
    {
        var entity = new Driver
        {
            UserId = dto.UserId,
            LicenseNumber = dto.LicenseNumber,
            LicenseExpiration = dto.LicenseExpiration,
            LicenseType = dto.LicenseType,
            VehicleId = dto.VehicleId
        };
        await _service.AddAsync(entity);
        return CreatedAtAction(nameof(Get), new { id = entity.Id }, new DriverDto(entity.Id, entity.UserId, entity.LicenseNumber, entity.LicenseExpiration, entity.LicenseType, entity.VehicleId));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, UpdateDriverDto dto)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null) return NotFound();

        entity.LicenseNumber = dto.LicenseNumber;
        entity.LicenseExpiration = dto.LicenseExpiration;
        entity.LicenseType = dto.LicenseType;
        entity.VehicleId = dto.VehicleId;

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
