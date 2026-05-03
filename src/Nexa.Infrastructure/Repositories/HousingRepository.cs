using Microsoft.EntityFrameworkCore;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;
using Nexa.Infrastructure.Persistence;
using Nexa.Infrastructure.Repositories.Base;

namespace Nexa.Infrastructure.Repositories;

public class HousingRepository : BaseRepository<Housing>, IHousingRepository
{
    public HousingRepository(AppDbContext context) : base(context) { }

    public override async Task<Housing?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(x => x.Address)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public override async Task<List<Housing>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(x => x.Address)
            .ToListAsync(cancellationToken);
    }

    public async Task<(int MaxCapacity, int CurrentCapacity)> GetHomePageData(CancellationToken cancellationToken = default)
    {
        var maxCapacity = await _dbSet.AsNoTracking().SumAsync(x => x.MaxCapacity, cancellationToken);
        var currentCapacity = await _dbSet.AsNoTracking().SumAsync(x => x.CurrentCapacity, cancellationToken);
        
        return (maxCapacity, currentCapacity);
    }
}
