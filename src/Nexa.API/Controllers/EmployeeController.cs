using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : BaseController<Employee, IEmployeeService, EmployeeDto, CreateEmployeeDto, UpdateEmployeeDto>
{
    public EmployeeController(IEmployeeService employeeService) : base(employeeService) { }

    protected override EmployeeDto MapToDto(Employee entity) =>
        new(entity.Id, entity.UserId, entity.Name, entity.Cpf, entity.Role, entity.PhoneNumber, entity.HireDate, entity.Status, entity.HousingId);
}
