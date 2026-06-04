using Microsoft.EntityFrameworkCore;
using Nexa.Domain.Entities;
using Nexa.Domain.Enums;
using Nexa.Domain.Interfaces.Repositories;
using Nexa.Infrastructure.Persistence;
using Nexa.Infrastructure.Repositories.Base;

namespace Nexa.Infrastructure.Repositories;

public class MovementRepository : BaseRepository<Movement>, IMovementRepository
{
    public MovementRepository(AppDbContext context) : base(context) { }

    public async Task<(List<Movement> Items, int TotalCount)> GetPagedAndFilteredAsync(
        string? search,
        List<MovementType>? types,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default)
    {
        var query = _dbSet.AsNoTracking().AsQueryable();

        if (types != null && types.Any())
        {
            query = query.Where(x => types.Contains(x.Type));
        }

        if (!string.IsNullOrWhiteSpace(search))
        {
            string searchLower = search.ToLower();
            query = query.Where(x =>
                x.Title.ToLower().Contains(searchLower) ||
                x.Description.ToLower().Contains(searchLower) ||
                x.StatusLabel.ToLower().Contains(searchLower));
        }

        int totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .OrderByDescending(x => x.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return (items, totalCount);
    }

    public async Task<Dictionary<MovementType, int>> GetCountsAsync(CancellationToken cancellationToken = default)
    {
        var groups = await _dbSet
            .GroupBy(x => x.Type)
            .Select(g => new { Type = g.Key, Count = g.Count() })
            .ToListAsync(cancellationToken);

        var result = Enum.GetValues<MovementType>()
            .ToDictionary(type => type, _ => 0);

        foreach (var g in groups)
        {
            result[g.Type] = g.Count;
        }

        return result;
    }
}
