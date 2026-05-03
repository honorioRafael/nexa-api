using Microsoft.EntityFrameworkCore;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;
using Nexa.Infrastructure.Persistence;
using Nexa.Infrastructure.Repositories.Base;

namespace Nexa.Infrastructure.Repositories;

public class HousingAllocationRepository : BaseRepository<HousingAllocation>, IHousingAllocationRepository
{
    private readonly AppDbContext _appContext;

    public HousingAllocationRepository(AppDbContext context) : base(context)
    {
        _appContext = context;
    }

    /// <summary>
    /// Regra centralizada de alocação ativa:
    /// Uma alocação é ativa se CheckOutDate é nulo OU se a data de checkout está no futuro (>= agora).
    /// </summary>
    private static bool IsActiveAllocation(HousingAllocation a, DateTime now)
        => a.CheckOutDate == null || a.CheckOutDate >= now;

    public async Task<List<HousingAllocation>> GetByHousingIdAsync(long housingId, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(x => x.HousingId == housingId)
            .Include(x => x.Employee)
            .Include(x => x.HousingRoom)
            .ToListAsync(cancellationToken);
    }

    public async Task<int> GetPendingCheckOutCount(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .AsNoTracking()
            .CountAsync(x => x.CheckOutDate == null, cancellationToken);
    }

    public async Task<int> GetCurrentOccupancyByHousingIdAsync(long housingId, CancellationToken cancellationToken = default)
    {
        var now = DateTime.UtcNow;
        return await _dbSet
            .AsNoTracking()
            .CountAsync(x => x.HousingId == housingId && (x.CheckOutDate == null || x.CheckOutDate >= now), cancellationToken);
    }

    public async Task<int> GetTotalCurrentOccupancyAsync(CancellationToken cancellationToken = default)
    {
        var now = DateTime.UtcNow;
        return await _dbSet
            .AsNoTracking()
            .CountAsync(x => x.CheckOutDate == null || x.CheckOutDate >= now, cancellationToken);
    }

    public async Task<int> GetFullHousingsCount(CancellationToken cancellationToken = default)
    {
        var now = DateTime.UtcNow;
        return await _appContext.Housing
            .AsNoTracking()
            .CountAsync(h =>
                _appContext.HousingAllocation
                    .Count(a => a.HousingId == h.Id && (a.CheckOutDate == null || a.CheckOutDate >= now))
                    >= h.MaxCapacity,
                cancellationToken);
    }
}
