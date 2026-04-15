using Microsoft.EntityFrameworkCore;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;
using Nexa.Infrastructure.Persistence;
using Nexa.Infrastructure.Repositories.Base;

namespace Nexa.Infrastructure.Repositories;

public class HousingAllocationRepository : BaseRepository<HousingAllocation>, IHousingAllocationRepository
{
    public HousingAllocationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<HousingAllocation>> GetByHousingIdAsync(long housingId, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(x => x.HousingId == housingId)
            .Include(x => x.Employee)
            .Include(x => x.HousingRoom)
            .ToListAsync(cancellationToken);
    }
}
