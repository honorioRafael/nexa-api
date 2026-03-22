using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class EmployeeService : BaseService<Employee, IEmployeeRepository, CreateEmployeeDto, UpdateEmployeeDto>, IEmployeeService
{
    public EmployeeService(IEmployeeRepository repository) : base(repository)
    {
    }
}
