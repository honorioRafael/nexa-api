using ErrorOr;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class DriverService : BaseService<Driver, IDriverRepository, CreateDriverDto, UpdateDriverDto>, IDriverService
{
    private readonly ICurrentUser _currentUser;
    private readonly IUserRepository _userRepository;
    private readonly IVehicleRepository _vehicleRepository;

    public DriverService(
        IDriverRepository repository, 
        ICurrentUser currentUser,
        IUserRepository userRepository,
        IVehicleRepository vehicleRepository) : base(repository)
    {
        _currentUser = currentUser;
        _userRepository = userRepository;
        _vehicleRepository = vehicleRepository;
    }

    protected override void OnCreateEntityMapped(Driver entity, CreateDriverDto createDto)
    {
        entity.UserId = _currentUser.Id!.Value;
    }

    public override async Task<ErrorOr<Success>> OnEntityCreating(CreateDriverDto createDto, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(_currentUser.Id!.Value, cancellationToken);
        if (user == null)
            return Error.NotFound(description: "User não encontrado.");

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
