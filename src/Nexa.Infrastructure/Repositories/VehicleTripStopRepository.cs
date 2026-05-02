using Microsoft.EntityFrameworkCore;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;
using Nexa.Infrastructure.Persistence;
using Nexa.Infrastructure.Repositories.Base;

namespace Nexa.Infrastructure.Repositories;

public class VehicleTripStopRepository : BaseRepository<VehicleTripStop>, IVehicleTripStopRepository
{
    public VehicleTripStopRepository(AppDbContext context) : base(context) { }

    public Task<bool> ExistsByQueuePositionAsync(long vehicleTripId, int queuePosition, CancellationToken cancellationToken = default)
    {
        return _dbSet.AnyAsync(x => x.VehicleTripId == vehicleTripId && x.QueuePosition == queuePosition, cancellationToken);
    }
}
