using Microsoft.EntityFrameworkCore;
using Nexa.Domain.Entities;
using Nexa.Domain.Enums;
using Nexa.Domain.Interfaces.Repositories;
using Nexa.Infrastructure.Persistence;
using Nexa.Infrastructure.Repositories.Base;

namespace Nexa.Infrastructure.Repositories;

public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
{
    public VehicleRepository(AppDbContext context) : base(context) { }

    public async Task<(int TotalVehicles, int AvailableVehicles)> GetHomePageData(CancellationToken cancellationToken = default)
    {
        var fetch = await _dbSet
            .AsNoTracking()
            .GroupBy(x => 1)
            .Select(g => new
            {
                TotalVehicles = g.Count(),
                AvailableVehicles = g.Count(x => x.Status == VehicleStatus.Available)
            })
            .FirstAsync(cancellationToken);
        return (fetch.TotalVehicles, fetch.AvailableVehicles);
    }
}
