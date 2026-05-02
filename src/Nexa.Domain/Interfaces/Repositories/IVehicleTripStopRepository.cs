using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories.Base;

namespace Nexa.Domain.Interfaces.Repositories;

public interface IVehicleTripStopRepository : IBaseRepository<VehicleTripStop>
{
    Task<bool> ExistsByQueuePositionAsync(long vehicleTripId, int queuePosition, CancellationToken cancellationToken = default);
}
