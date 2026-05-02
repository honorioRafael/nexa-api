using ErrorOr;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class VehicleTripStopService : BaseService<VehicleTripStop, IVehicleTripStopRepository, CreateVehicleTripStopDto, UpdateVehicleTripStopDto>, IVehicleTripStopService
{
    private readonly IVehicleTripRepository _vehicleTripRepository;
    private readonly IAddressRepository _addressRepository;

    public VehicleTripStopService(
        IVehicleTripStopRepository repository,
        IVehicleTripRepository vehicleTripRepository,
        IAddressRepository addressRepository) : base(repository)
    {
        _vehicleTripRepository = vehicleTripRepository;
        _addressRepository = addressRepository;
    }

    public override async Task<ErrorOr<Success>> OnEntityCreating(CreateVehicleTripStopDto createDto, CancellationToken cancellationToken = default)
    {
        var vehicleTrip = await _vehicleTripRepository.GetByIdAsync(createDto.VehicleTripId, cancellationToken);
        if (vehicleTrip == null)
            return Error.NotFound(description: "VehicleTrip não encontrado.");

        var address = await _addressRepository.GetByIdAsync(createDto.AddressId, cancellationToken);
        if (address == null)
            return Error.NotFound(description: "Address não encontrado.");

        bool existsQueue = await _repository.ExistsByQueuePositionAsync(createDto.VehicleTripId, createDto.QueuePosition, cancellationToken);
        if (existsQueue)
            return Error.Conflict(description: "Já existe uma parada com esta Posição na Fila para esta Viagem.");

        return Result.Success;
    }

    public override async Task<ErrorOr<Success>> OnEntityUpdating(long id, UpdateVehicleTripStopDto updateDto, CancellationToken cancellationToken = default)
    {
        var existingStop = await _repository.GetByIdAsync(id, cancellationToken);
        if (existingStop == null)
            return Error.NotFound(description: "VehicleTripStop não encontrado.");

        var address = await _addressRepository.GetByIdAsync(updateDto.AddressId, cancellationToken);
        if (address == null)
            return Error.NotFound(description: "Address não encontrado.");

        if (existingStop.QueuePosition != updateDto.QueuePosition)
        {
            bool existsQueue = await _repository.ExistsByQueuePositionAsync(existingStop.VehicleTripId, updateDto.QueuePosition, cancellationToken);
            if (existsQueue)
                return Error.Conflict(description: "Já existe uma parada com esta Posição na Fila para esta Viagem.");
        }

        return Result.Success;
    }
}
