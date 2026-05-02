using ErrorOr;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class VehicleMaintenanceService : BaseService<VehicleMaintenance, IVehicleMaintenanceRepository, CreateVehicleMaintenanceDto, UpdateVehicleMaintenanceDto>, IVehicleMaintenanceService
{
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleMaintenanceService(IVehicleMaintenanceRepository repository, IVehicleRepository vehicleRepository) : base(repository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public override async Task<ErrorOr<Success>> OnEntityCreating(CreateVehicleMaintenanceDto createDto, CancellationToken cancellationToken = default)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(createDto.VehicleId, cancellationToken);
        if (vehicle == null)
            return Error.NotFound(description: "Veículo não encontrado.");

        return Result.Success;
    }

    public override async Task<ErrorOr<Success>> OnEntityUpdating(long id, UpdateVehicleMaintenanceDto updateDto, CancellationToken cancellationToken = default)
    {
        if (updateDto.EndDate.HasValue)
        {
            var existingMaintenance = await _repository.GetByIdAsync(id, cancellationToken);
            if (existingMaintenance == null)
                return Error.NotFound(description: "Manutenção não encontrada.");

            if (updateDto.EndDate.Value < existingMaintenance.StartDate)
                return Error.Validation(description: "A data de término não pode ser menor que a data de início.");
        }

        return Result.Success;
    }
}
