using ErrorOr;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Enums;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class VehicleTripService : BaseService<VehicleTrip, IVehicleTripRepository, CreateVehicleTripDto, UpdateVehicleTripDto>, IVehicleTripService
{
    private readonly IHousingRepository _housingRepository;
    private readonly IDriverRepository _driverRepository;
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IAddressRepository _addressRepository;
    private readonly IVehicleModelRepository _vehicleModelRepository;
    private readonly IMovementRepository _movementRepository;

    public VehicleTripService(
        IVehicleTripRepository repository, 
        IHousingRepository housingRepository,
        IDriverRepository driverRepository,
        IVehicleRepository vehicleRepository,
        IAddressRepository addressRepository,
        IVehicleModelRepository vehicleModelRepository,
        IMovementRepository movementRepository) : base(repository)
    {
        _housingRepository = housingRepository;
        _driverRepository = driverRepository;
        _vehicleRepository = vehicleRepository;
        _addressRepository = addressRepository;
        _vehicleModelRepository = vehicleModelRepository;
        _movementRepository = movementRepository;
    }

    public override async Task<ErrorOr<Success>> OnEntityCreating(CreateVehicleTripDto createDto, CancellationToken cancellationToken = default)
    {
        var driver = await _driverRepository.GetByIdAsync(createDto.DriverId, cancellationToken);
        if (driver == null)
            return Error.NotFound(description: "Motorista não encontrado.");

        var vehicle = await _vehicleRepository.GetByIdAsync(createDto.VehicleId, cancellationToken);
        if (vehicle == null)
            return Error.NotFound(description: "Veículo não encontrado.");

        var originAddress = await _addressRepository.GetByIdAsync(createDto.OriginAddressId, cancellationToken);
        if (originAddress == null)
            return Error.NotFound(description: "Endereço de origem não encontrado.");

        var destinationAddress = await _addressRepository.GetByIdAsync(createDto.DestinationAddressId, cancellationToken);
        if (destinationAddress == null)
            return Error.NotFound(description: "Endereço de destino não encontrado.");

        return Result.Success;
    }

    public override async Task<ErrorOr<Success>> OnEntityUpdating(long id, UpdateVehicleTripDto updateDto, CancellationToken cancellationToken = default)
    {
        return Result.Success;
    }

    public async Task<ErrorOr<VehicleTrip>> GetLastByVehicleIdAsync(long vehicleId, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetLastByVehicleIdAsync(vehicleId, cancellationToken);
        if (entity is null)
            return Error.NotFound(description: $"Não foi encontrado nenhum registro para o veículo {vehicleId}");

        return entity;
    }

    public async Task<ErrorOr<List<VehicleTripDto>>> GetByHousingIdAsync(long housingId, CancellationToken cancellationToken = default)
    {
        var housing = await _housingRepository.GetByIdAsync(housingId, cancellationToken);
        if (housing is null)
            return Error.NotFound(description: $"Housing com Id {housingId} não encontrado(a).");

        var entities = await _repository.GetByAddressIdAsync(housing.AddressId, cancellationToken);
        return entities.Select(e => (VehicleTripDto)e!).ToList();
    }

    public override async Task<ErrorOr<VehicleTrip>> CreateAsync(CreateVehicleTripDto dto, CancellationToken cancellationToken = default)
    {
        var result = await base.CreateAsync(dto, cancellationToken);
        if (result.IsError) return result.Errors;

        var trip = result.Value;

        if (trip.Status == VehicleTripStatus.InProgress)
        {
            var vehicleDesc = await GetVehicleDescriptionAsync(trip.VehicleId, cancellationToken);
            await _movementRepository.CreateAsync(new Movement
            {
                Type = MovementType.VehicleTripStarted,
                Title = "Viagem iniciada",
                Description = $"Veículo <b>{vehicleDesc}</b> iniciou a viagem",
                StatusLabel = "Em andamento",
                CreatedAt = DateTime.UtcNow,
                VehicleId = trip.VehicleId
            }, cancellationToken);
            await _movementRepository.SaveChangesAsync(cancellationToken);
        }

        return trip;
    }

    public override async Task<ErrorOr<VehicleTrip>> UpdateAsync(long id, UpdateVehicleTripDto dto, CancellationToken cancellationToken = default)
    {
        var existingTrip = await _repository.GetByIdAsync(id, cancellationToken);
        if (existingTrip is null)
            return Error.NotFound(description: $"VehicleTrip com Id {id} não encontrado(a).");

        var oldStatus = existingTrip.Status;

        var result = await base.UpdateAsync(id, dto, cancellationToken);
        if (result.IsError) return result.Errors;

        var updatedTrip = result.Value;

        if (oldStatus != updatedTrip.Status)
        {
            if (updatedTrip.Status == VehicleTripStatus.InProgress)
            {
                var vehicleDesc = await GetVehicleDescriptionAsync(updatedTrip.VehicleId, cancellationToken);
                await _movementRepository.CreateAsync(new Movement
                {
                    Type = MovementType.VehicleTripStarted,
                    Title = "Viagem iniciada",
                    Description = $"Veículo <b>{vehicleDesc}</b> iniciou a viagem",
                    StatusLabel = "Em andamento",
                    CreatedAt = DateTime.UtcNow,
                    VehicleId = updatedTrip.VehicleId
                }, cancellationToken);
                await _movementRepository.SaveChangesAsync(cancellationToken);
            }
            else if (updatedTrip.Status == VehicleTripStatus.Completed)
            {
                var vehicleDesc = await GetVehicleDescriptionAsync(updatedTrip.VehicleId, cancellationToken);
                await _movementRepository.CreateAsync(new Movement
                {
                    Type = MovementType.VehicleTripCompleted,
                    Title = "Viagem Finalizada",
                    Description = $"Veículo <b>{vehicleDesc}</b> finalizou a viagem",
                    StatusLabel = "Concluída",
                    CreatedAt = DateTime.UtcNow,
                    VehicleId = updatedTrip.VehicleId
                }, cancellationToken);
                await _movementRepository.SaveChangesAsync(cancellationToken);
            }
        }

        return updatedTrip;
    }

    private async Task<string> GetVehicleDescriptionAsync(long vehicleId, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(vehicleId, cancellationToken);
        if (vehicle == null) return "Veículo Desconhecido";

        var model = await _vehicleModelRepository.GetByIdAsync(vehicle.VehicleModelId, cancellationToken);
        var modelName = model?.Model ?? "Modelo Desconhecido";

        return $"{vehicle.LicensePlate} ({modelName})";
    }
}
