using ErrorOr;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Enums;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class HousingAllocationService : BaseService<HousingAllocation, IHousingAllocationRepository, CreateHousingAllocationDto, UpdateHousingAllocationDto>, IHousingAllocationService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IHousingRepository _housingRepository;
    private readonly IMovementRepository _movementRepository;

    public HousingAllocationService(
        IHousingAllocationRepository repository,
        IEmployeeRepository employeeRepository,
        IHousingRepository housingRepository,
        IMovementRepository movementRepository) : base(repository)
    {
        _employeeRepository = employeeRepository;
        _housingRepository = housingRepository;
        _movementRepository = movementRepository;
    }

    public override async Task<ErrorOr<Success>> OnEntityCreating(CreateHousingAllocationDto createDto, CancellationToken cancellationToken = default)
    {
        var employee = await _employeeRepository.GetByIdAsync(createDto.EmployeeId, cancellationToken);
        if (employee == null)
            return Error.NotFound(description: "Employee não encontrado.");

        var housing = await _housingRepository.GetByIdAsync(createDto.HousingId, cancellationToken);
        if (housing == null)
            return Error.NotFound(description: "Housing não encontrado.");

        if (housing.UseHousingRoom && (!createDto.HousingRoomId.HasValue || createDto.HousingRoomId <= 0))
            return Error.Validation(description: "HousingRoomId é obrigatório quando o Housing utiliza quartos.");

        return Result.Success;
    }

    public override async Task<ErrorOr<Success>> OnEntityUpdating(long id, UpdateHousingAllocationDto updateDto, CancellationToken cancellationToken = default)
    {
        var existingAllocation = await _repository.GetByIdAsync(id, cancellationToken);
        if (existingAllocation == null)
            return Error.NotFound(description: "HousingAllocation não encontrado.");

        var housing = await _housingRepository.GetByIdAsync(existingAllocation.HousingId, cancellationToken);
        if (housing == null)
            return Error.NotFound(description: "Housing não encontrado.");

        if (housing.UseHousingRoom && (!updateDto.HousingRoomId.HasValue || updateDto.HousingRoomId <= 0))
            return Error.Validation(description: "HousingRoomId é obrigatório quando o Housing utiliza quartos.");

        if (updateDto.CheckOutDate.HasValue && existingAllocation.CheckInDate > updateDto.CheckOutDate.Value)
            return Error.Validation(description: "A data de check-out deve ser maior ou igual à data de check-in.");

        return Result.Success;
    }

    public async Task<List<HousingAllocationDto>> GetByHousingIdAsync(long housingId, CancellationToken cancellationToken = default)
    {
        var entities = await _repository.GetByHousingIdAsync(housingId, cancellationToken);
        return entities.Select(e => (HousingAllocationDto)e!).ToList();
    }

    public override async Task<ErrorOr<HousingAllocation>> CreateAsync(CreateHousingAllocationDto dto, CancellationToken cancellationToken = default)
    {
        var result = await base.CreateAsync(dto, cancellationToken);
        if (result.IsError) return result.Errors;

        var allocation = result.Value;

        var employee = await _employeeRepository.GetByIdAsync(allocation.EmployeeId, cancellationToken);
        var employeeName = employee?.Name ?? "Funcionário";

        var housing = await _housingRepository.GetByIdAsync(allocation.HousingId, cancellationToken);
        var housingName = housing?.Name ?? "Alojamento";

        var employeeAllocations = await _repository.GetAllAsync(cancellationToken);
        var previousAllocation = employeeAllocations
            .Where(x => x.EmployeeId == allocation.EmployeeId && x.Id != allocation.Id)
            .OrderByDescending(x => x.CheckOutDate ?? x.CheckInDate)
            .FirstOrDefault();

        if (previousAllocation != null)
        {
            var oldHousing = await _housingRepository.GetByIdAsync(previousAllocation.HousingId, cancellationToken);
            var oldHousingName = oldHousing?.Name ?? "Alojamento Anterior";

            await _movementRepository.CreateAsync(new Movement
            {
                Type = MovementType.HousingTransfer,
                Title = "Transferência de Alojamento",
                Description = $"Funcionário <b>{employeeName}</b> transferido de <b>{oldHousingName}</b> para <b>{housingName}</b>",
                StatusLabel = "Transferido",
                CreatedAt = DateTime.UtcNow,
                EmployeeId = allocation.EmployeeId,
                HousingId = allocation.HousingId
            }, cancellationToken);
        }
        else
        {
            await _movementRepository.CreateAsync(new Movement
            {
                Type = MovementType.HousingCheckIn,
                Title = "Novo Funcionário Adicionado ao Alojamento",
                Description = $"O funcionário <b>{employeeName}</b> foi alocado no <b>{housingName}</b>",
                StatusLabel = "Transferido",
                CreatedAt = DateTime.UtcNow,
                EmployeeId = allocation.EmployeeId,
                HousingId = allocation.HousingId
            }, cancellationToken);
        }

        await _movementRepository.SaveChangesAsync(cancellationToken);

        return allocation;
    }

    public override async Task<ErrorOr<HousingAllocation>> UpdateAsync(long id, UpdateHousingAllocationDto dto, CancellationToken cancellationToken = default)
    {
        var existingAllocation = await _repository.GetByIdAsync(id, cancellationToken);
        if (existingAllocation is null)
            return Error.NotFound(description: $"HousingAllocation com Id {id} não encontrado(a).");

        var oldCheckOutDate = existingAllocation.CheckOutDate;

        var result = await base.UpdateAsync(id, dto, cancellationToken);
        if (result.IsError) return result.Errors;

        var updatedAllocation = result.Value;

        if (oldCheckOutDate == null && updatedAllocation.CheckOutDate != null)
        {
            var employee = await _employeeRepository.GetByIdAsync(updatedAllocation.EmployeeId, cancellationToken);
            var employeeName = employee?.Name ?? "Funcionário";

            var housing = await _housingRepository.GetByIdAsync(updatedAllocation.HousingId, cancellationToken);
            var housingName = housing?.Name ?? "Alojamento";

            await _movementRepository.CreateAsync(new Movement
            {
                Type = MovementType.HousingCheckOut,
                Title = "Saída de Alojamento",
                Description = $"Funcionário <b>{employeeName}</b> fez check-out do <b>{housingName}</b>",
                StatusLabel = "Saída",
                CreatedAt = DateTime.UtcNow,
                EmployeeId = updatedAllocation.EmployeeId,
                HousingId = updatedAllocation.HousingId
            }, cancellationToken);

            await _movementRepository.SaveChangesAsync(cancellationToken);
        }

        return updatedAllocation;
    }
}
