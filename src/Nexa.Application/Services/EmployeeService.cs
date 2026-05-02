using ErrorOr;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class EmployeeService : BaseService<Employee, IEmployeeRepository, CreateEmployeeDto, UpdateEmployeeDto>, IEmployeeService
{
    private readonly ICurrentUser _currentUser;
    private readonly IUserRepository _userRepository;
    private readonly IHousingRepository _housingRepository;

    public EmployeeService(
        IEmployeeRepository repository, 
        ICurrentUser currentUser,
        IUserRepository userRepository,
        IHousingRepository housingRepository) : base(repository)
    {
        _currentUser = currentUser;
        _userRepository = userRepository;
        _housingRepository = housingRepository;
    }

    protected override void OnCreateEntityMapped(Employee entity, CreateEmployeeDto createDto)
    {
        entity.UserId = _currentUser.Id!.Value;
    }

    public override async Task<ErrorOr<Success>> OnEntityCreating(CreateEmployeeDto createDto, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(_currentUser.Id!.Value, cancellationToken);
        if (user == null)
            return Error.NotFound(description: "User não encontrado.");

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
