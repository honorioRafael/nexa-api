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

    public VehicleTripService(IVehicleTripRepository repository, IHousingRepository housingRepository) : base(repository)
    {
        _housingRepository = housingRepository;
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
