using Nexa.Domain.Entities;
using Nexa.Domain.Enums;
using Nexa.Domain.Interfaces.Repositories.Base;

namespace Nexa.Domain.Interfaces.Repositories;

public interface IMovementRepository : IBaseRepository<Movement>
{
    Task<(List<Movement> Items, int TotalCount)> GetPagedAndFilteredAsync(
        string? search,
        List<MovementType>? types,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default);

    Task<Dictionary<MovementType, int>> GetCountsAsync(CancellationToken cancellationToken = default);
}
