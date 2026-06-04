using ErrorOr;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Enums;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class EmployeeService : BaseService<Employee, IEmployeeRepository, CreateEmployeeDto, UpdateEmployeeDto>, IEmployeeService
{
    private readonly IHousingRepository _housingRepository;
    private readonly IMovementRepository _movementRepository;

    public EmployeeService(
        IEmployeeRepository repository, 
        IHousingRepository housingRepository,
        IMovementRepository movementRepository) : base(repository)
    {
        _housingRepository = housingRepository;
        _movementRepository = movementRepository;
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

    public override async Task<ErrorOr<Employee>> UpdateAsync(long id, UpdateEmployeeDto dto, CancellationToken cancellationToken = default)
    {
        var existingEmployee = await _repository.GetByIdAsync(id, cancellationToken);
        if (existingEmployee is null)
            return Error.NotFound(description: $"Employee com Id {id} não encontrado(a).");

        var oldStatus = existingEmployee.Status;

        var result = await base.UpdateAsync(id, dto, cancellationToken);
        if (result.IsError) return result.Errors;

        var updatedEmployee = result.Value;
        if (oldStatus != updatedEmployee.Status)
        {
            await _movementRepository.CreateAsync(new Movement
            {
                Type = MovementType.EmployeeStatusChange,
                Title = "Alteração de Status",
                Description = $"Status de <b>{updatedEmployee.Name}</b> alterado de {FriendlyEmployeeStatus(oldStatus)} para <b>{FriendlyEmployeeStatus(updatedEmployee.Status)}</b>",
                StatusLabel = FriendlyEmployeeStatus(updatedEmployee.Status),
                CreatedAt = DateTime.UtcNow,
                EmployeeId = updatedEmployee.Id
            }, cancellationToken);
            await _movementRepository.SaveChangesAsync(cancellationToken);
        }

        return updatedEmployee;
    }

    private static string FriendlyEmployeeStatus(EmployeeStatus status) => status switch
    {
        EmployeeStatus.Active => "Ativo",
        EmployeeStatus.OnVacation => "De Férias",
        EmployeeStatus.Dismissed => "Demitido",
        _ => status.ToString()
    };
}
