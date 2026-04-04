using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

public class EmployeeController : BaseController<Employee, IEmployeeService, EmployeeDto, CreateEmployeeDto, UpdateEmployeeDto>
{
    public EmployeeController(IEmployeeService employeeService) : base(employeeService) { }


}

