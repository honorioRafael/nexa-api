using ErrorOr;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class EmployeeService : BaseService<Employee, IEmployeeRepository, CreateEmployeeDto, UpdateEmployeeDto>, IEmployeeService
{
    private readonly IHousingRepository _housingRepository;

    public EmployeeService(
        IEmployeeRepository repository, 
        IHousingRepository housingRepository) : base(repository)
    {
        _housingRepository = housingRepository;
    }

    public override async Task<ErrorOr<Success>> OnEntityCreating(CreateEmployeeDto createDto, CancellationToken cancellationToken = default)
    {
        var existingEmployee = await _repository.GetByCpfAsync(createDto.Cpf, cancellationToken);
        if (existingEmployee != null)
            return Error.Conflict(description: "Já existe um funcionário com este CPF.");

        return Result.Success;
    }

    public override async Task<ErrorOr<Success>> OnEntityUpdating(long id, UpdateEmployeeDto updateDto, CancellationToken cancellationToken = default)
    {
        var existingEmployee = await _repository.GetByCpfAsync(updateDto.Cpf, cancellationToken);
        if (existingEmployee != null && existingEmployee.Id != id)
            return Error.Conflict(description: "Já existe um funcionário com este CPF.");

        return Result.Success;
    }
}
