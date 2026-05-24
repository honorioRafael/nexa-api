using ErrorOr;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class DriverService : BaseService<Driver, IDriverRepository, CreateDriverDto, UpdateDriverDto>, IDriverService
{
    private readonly IVehicleRepository _vehicleRepository;

    public DriverService(
        IDriverRepository repository, 
        IVehicleRepository vehicleRepository) : base(repository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public override async Task<ErrorOr<Success>> OnEntityCreating(CreateDriverDto createDto, CancellationToken cancellationToken = default)
    {
        if (createDto.VehicleId.HasValue)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(createDto.VehicleId.Value, cancellationToken);
            if (vehicle == null)
                return Error.NotFound(description: "Vehicle não encontrado.");
        }

        var existingDriver = await _repository.GetByLicenseNumberAsync(createDto.LicenseNumber, cancellationToken);
        if (existingDriver != null)
            return Error.Conflict(description: "Já existe um motorista com esta CNH.");

        return Result.Success;
    }

    public override async Task<ErrorOr<Success>> OnEntityUpdating(long id, UpdateDriverDto updateDto, CancellationToken cancellationToken = default)
    {
        if (updateDto.VehicleId.HasValue)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(updateDto.VehicleId.Value, cancellationToken);
            if (vehicle == null)
                return Error.NotFound(description: "Vehicle não encontrado.");
        }

        var existingDriver = await _repository.GetByLicenseNumberAsync(updateDto.LicenseNumber, cancellationToken);
        if (existingDriver != null && existingDriver.Id != id)
            return Error.Conflict(description: "Já existe um motorista com esta CNH.");

        return Result.Success;
    }
}
