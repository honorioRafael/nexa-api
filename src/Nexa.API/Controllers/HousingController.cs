using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HousingController : BaseController<Housing, IHousingService>
{

    public HousingController(IHousingService housingService) : base(housingService)
    {
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null) return NotFound();
        return Ok(new HousingDto(entity.Id, entity.Name, entity.Address, entity.City, entity.ZipCode, entity.MaxCapacity, entity.CurrentCapacity, entity.Status));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var entities = await _service.GetAllAsync();
        return Ok(entities.Select(e => new HousingDto(e.Id, e.Name, e.Address, e.City, e.ZipCode, e.MaxCapacity, e.CurrentCapacity, e.Status)));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateHousingDto dto)
    {
        var entity = new Housing
        {
            Name = dto.Name,
            Address = dto.Address,
            City = dto.City,
            ZipCode = dto.ZipCode,
            MaxCapacity = dto.MaxCapacity,
            CurrentCapacity = dto.CurrentCapacity,
            Status = dto.Status
        };
        await _service.AddAsync(entity);
        return CreatedAtAction(nameof(Get), new { id = entity.Id }, new HousingDto(entity.Id, entity.Name, entity.Address, entity.City, entity.ZipCode, entity.MaxCapacity, entity.CurrentCapacity, entity.Status));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, UpdateHousingDto dto)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null) return NotFound();

        entity.Name = dto.Name;
        entity.Address = dto.Address;
        entity.City = dto.City;
        entity.ZipCode = dto.ZipCode;
        entity.MaxCapacity = dto.MaxCapacity;
        entity.CurrentCapacity = dto.CurrentCapacity;
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
