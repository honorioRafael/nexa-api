using ErrorOr;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class VehicleTripService : BaseService<VehicleTrip, IVehicleTripRepository, CreateVehicleTripDto, UpdateVehicleTripDto>, IVehicleTripService
{
    public VehicleTripService(IVehicleTripRepository repository) : base(repository) { }

    public async Task<ErrorOr<VehicleTrip>> GetLastByVehicleIdAsync(long vehicleId, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetLastByVehicleIdAsync(vehicleId, cancellationToken);
        if (entity is null)
            return Error.NotFound(description: $"Não foi encontrado nenhum registro para o veículo {vehicleId}");

        return entity;
    }
}
