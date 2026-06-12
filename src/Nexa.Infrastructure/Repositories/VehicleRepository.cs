using Microsoft.EntityFrameworkCore;
using Nexa.Domain.Entities;
using Nexa.Domain.Enums;
using Nexa.Domain.Interfaces.Repositories;
using Nexa.Domain.Models;
using Nexa.Infrastructure.Persistence;
using Nexa.Infrastructure.Repositories.Base;

namespace Nexa.Infrastructure.Repositories;

public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
{
    public VehicleRepository(AppDbContext context) : base(context) { }

    public async Task<List<Vehicle>> GetAllWithModelAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .AsNoTracking()
            .Include(x => x.VehicleModel)
            .ToListAsync(cancellationToken);
    }

    public async Task<HomePageVehicleStats> GetHomePageData(CancellationToken cancellationToken = default)
    {
        var stats = await _dbSet
            .AsNoTracking()
            .GroupBy(x => 1)
            .Select(g => new
            {
                Total = g.Count(),
                Available = g.Count(x => x.Status == VehicleStatus.Available),
                InUse = g.Count(x => x.Status == VehicleStatus.InUse),
                Maintenance = g.Count(x => x.Status == VehicleStatus.Maintenance)
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (stats == null)
        {
            return new HomePageVehicleStats(0, 0, 0, 0);
        }

        return new HomePageVehicleStats(stats.Total, stats.Available, stats.InUse, stats.Maintenance);
    }

    public async Task<List<VehicleTripCount>> GetTopUtilizedVehiclesAsync(
        int limit,
        DateTime? startDate = null,
        DateTime? endDate = null,
        CancellationToken cancellationToken = default)
    {
        var query = _dbSet.AsNoTracking().Include(v => v.VehicleModel);

        var projectedQuery = query.Select(v => new
        {
            Vehicle = v,
            TripCount = _context.VehicleTrip.Count(t =>
                t.VehicleId == v.Id &&
                (!startDate.HasValue || t.StartDate >= startDate.Value) &&
                (!endDate.HasValue || t.StartDate <= endDate.Value))
        });

        var list = await projectedQuery
            .OrderByDescending(x => x.TripCount)
            .Take(limit)
            .ToListAsync(cancellationToken);

        return list.Select(x => new VehicleTripCount(x.Vehicle, x.TripCount)).ToList();
    }

    public Task<Vehicle?> GetByLicensePlateAsync(string licensePlate, CancellationToken cancellationToken = default)
    {
        return _dbSet.FirstOrDefaultAsync(x => x.LicensePlate == licensePlate, cancellationToken);
    }

    public Task<Vehicle?> GetByChassisNumberAsync(string chassisNumber, CancellationToken cancellationToken = default)
    {
        return _dbSet.FirstOrDefaultAsync(x => x.ChassisNumber == chassisNumber, cancellationToken);
    }
}
