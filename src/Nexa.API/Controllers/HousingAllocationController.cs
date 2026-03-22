using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HousingAllocationController : BaseController<HousingAllocation, IHousingAllocationService, CreateHousingAllocationDto, UpdateHousingAllocationDto>
{

    public HousingAllocationController(IHousingAllocationService housingAllocationService) : base(housingAllocationService)
    {
    }
    #region Get
    [HttpGet("Get/{id}")]
    public override async Task<IActionResult> Get(long id)
    {
        try
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity == null) return NotFound();
            return Ok(new HousingAllocationDto(entity.Id, entity.EmployeeId, entity.HousingId, entity.CheckInDate, entity.CheckOutDate));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("GetAll")]
    public override async Task<IActionResult> GetAll()
    {
        try
        {
            var entities = await _service.GetAllAsync();
            return Ok(entities.Select(e => new HousingAllocationDto(e.Id, e.EmployeeId, e.HousingId, e.CheckInDate, e.CheckOutDate)));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion

    #region Create
    [HttpPost("Create")]
    public override async Task<IActionResult> Create(CreateHousingAllocationDto dto)
    {
        try
        {
            var entity = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, new HousingAllocationDto(entity.Id, entity.EmployeeId, entity.HousingId, entity.CheckInDate, entity.CheckOutDate));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("CreateMultiple")]
    public override async Task<IActionResult> CreateMultiple(List<CreateHousingAllocationDto> dtos)
    {
        try
        {
            var entities = await _service.CreateMultipleAsync(dtos);
            return Ok(entities.Select(e => new HousingAllocationDto(e.Id, e.EmployeeId, e.HousingId, e.CheckInDate, e.CheckOutDate)));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion

    #region Update
    [HttpPut("Update/{id}")]
    public override async Task<IActionResult> Update(long id, UpdateHousingAllocationDto dto)
    {
        try
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("UpdateMultiple")]
    public override async Task<IActionResult> UpdateMultiple(Dictionary<long, UpdateHousingAllocationDto> idDtoPairs)
    {
        try
        {
            await _service.UpdateMultipleAsync(idDtoPairs);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion

    #region Delete
    [HttpDelete("Delete/{id}")]
    public override async Task<IActionResult> Delete(long id)
    {
        try
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("DeleteMultiple")]
    public override async Task<IActionResult> DeleteMultiple(List<long> listid)
    {
        try
        {
            await _service.DeleteMultipleAsync(listid);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion
}
