using ErrorOr;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class HousingAllocationService : BaseService<HousingAllocation, IHousingAllocationRepository, CreateHousingAllocationDto, UpdateHousingAllocationDto>, IHousingAllocationService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IHousingRepository _housingRepository;

    public HousingAllocationService(
        IHousingAllocationRepository repository,
        IEmployeeRepository employeeRepository,
        IHousingRepository housingRepository) : base(repository)
    {
        _employeeRepository = employeeRepository;
        _housingRepository = housingRepository;
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
}
