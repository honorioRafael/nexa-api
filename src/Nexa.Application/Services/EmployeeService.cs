using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class EmployeeService : BaseService<Employee, IEmployeeRepository, CreateEmployeeDto, UpdateEmployeeDto>, IEmployeeService
{
    private readonly ICurrentUser _currentUser;

    public EmployeeService(IEmployeeRepository repository, ICurrentUser currentUser) : base(repository)
    {
        _currentUser = currentUser;
    }

    protected override void OnCreateEntityMapped(Employee entity, CreateEmployeeDto createDto)
    {
        entity.UserId = _currentUser.Id!.Value;
    }
}
