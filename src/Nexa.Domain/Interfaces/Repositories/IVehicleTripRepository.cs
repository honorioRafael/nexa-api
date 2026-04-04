using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories.Base;

namespace Nexa.Domain.Interfaces.Repositories;

public interface IVehicleTripRepository : IBaseRepository<VehicleTrip>
{
    Task<VehicleTrip?> GetLastByVehicleIdAsync(long vehicleId, CancellationToken cancellationToken = default);
}
