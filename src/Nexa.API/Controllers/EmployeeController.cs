using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : BaseController<Employee, IEmployeeService>
{

    public EmployeeController(IEmployeeService employeeService) : base(employeeService)
    {
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null) return NotFound();
        return Ok(new EmployeeDto(entity.Id, entity.UserId, entity.Name, entity.Cpf, entity.Role, entity.PhoneNumber, entity.HireDate, entity.Status, entity.HousingId));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var entities = await _service.GetAllAsync();
        return Ok(entities.Select(e => new EmployeeDto(e.Id, e.UserId, e.Name, e.Cpf, e.Role, e.PhoneNumber, e.HireDate, e.Status, e.HousingId)));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeDto dto)
    {
        var entity = new Employee
        {
            UserId = dto.UserId,
            Name = dto.Name,
            Cpf = dto.Cpf,
            Role = dto.Role,
            PhoneNumber = dto.PhoneNumber,
            HireDate = dto.HireDate,
            Status = dto.Status,
            HousingId = dto.HousingId
        };
        await _service.AddAsync(entity);
        return CreatedAtAction(nameof(Get), new { id = entity.Id }, new EmployeeDto(entity.Id, entity.UserId, entity.Name, entity.Cpf, entity.Role, entity.PhoneNumber, entity.HireDate, entity.Status, entity.HousingId));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, UpdateEmployeeDto dto)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null) return NotFound();

        entity.Name = dto.Name;
        entity.Role = dto.Role;
        entity.PhoneNumber = dto.PhoneNumber;
        entity.Status = dto.Status;
        entity.HousingId = dto.HousingId;

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
