using Microsoft.EntityFrameworkCore;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;
using Nexa.Infrastructure.Persistence;
using Nexa.Infrastructure.Repositories.Base;

namespace Nexa.Infrastructure.Repositories;

public class VehicleMaintenanceRepository : BaseRepository<VehicleMaintenance>, IVehicleMaintenanceRepository
{
    public VehicleMaintenanceRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<int> GetOpenMaintenancesCount(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .AsNoTracking()
            .CountAsync(x => x.EndDate == null, cancellationToken);
    }
}

