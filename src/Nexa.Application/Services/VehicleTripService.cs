using ErrorOr;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class VehicleTripService : BaseService<VehicleTrip, IVehicleTripRepository, CreateVehicleTripDto, UpdateVehicleTripDto>, IVehicleTripService
{
    private readonly IHousingRepository _housingRepository;
    private readonly IDriverRepository _driverRepository;
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IAddressRepository _addressRepository;

    public VehicleTripService(
        IVehicleTripRepository repository, 
        IHousingRepository housingRepository,
        IDriverRepository driverRepository,
        IVehicleRepository vehicleRepository,
        IAddressRepository addressRepository) : base(repository)
    {
        _housingRepository = housingRepository;
        _driverRepository = driverRepository;
        _vehicleRepository = vehicleRepository;
        _addressRepository = addressRepository;
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
}
