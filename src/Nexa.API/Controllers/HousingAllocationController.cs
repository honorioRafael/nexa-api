using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HousingAllocationController : BaseController<HousingAllocation, IHousingAllocationService>
{

    public HousingAllocationController(IHousingAllocationService housingAllocationService) : base(housingAllocationService)
    {
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null) return NotFound();
        return Ok(new HousingAllocationDto(entity.Id, entity.EmployeeId, entity.HousingId, entity.CheckInDate, entity.CheckOutDate));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var entities = await _service.GetAllAsync();
        return Ok(entities.Select(e => new HousingAllocationDto(e.Id, e.EmployeeId, e.HousingId, e.CheckInDate, e.CheckOutDate)));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateHousingAllocationDto dto)
    {
        var entity = new HousingAllocation
        {
            EmployeeId = dto.EmployeeId,
            HousingId = dto.HousingId,
            CheckInDate = dto.CheckInDate,
            CheckOutDate = dto.CheckOutDate
        };
        await _service.AddAsync(entity);
        return CreatedAtAction(nameof(Get), new { id = entity.Id }, new HousingAllocationDto(entity.Id, entity.EmployeeId, entity.HousingId, entity.CheckInDate, entity.CheckOutDate));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, UpdateHousingAllocationDto dto)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null) return NotFound();

        entity.CheckOutDate = dto.CheckOutDate;

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
