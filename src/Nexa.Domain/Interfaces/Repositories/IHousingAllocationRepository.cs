using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories.Base;

namespace Nexa.Domain.Interfaces.Repositories;

public interface IHousingAllocationRepository : IBaseRepository<HousingAllocation>
{
    Task<List<HousingAllocation>> GetByHousingIdAsync(long housingId, CancellationToken cancellationToken = default);
    Task<int> GetPendingCheckOutCount(CancellationToken cancellationToken = default);
    Task<int> GetCurrentOccupancyByHousingIdAsync(long housingId, CancellationToken cancellationToken = default);
    Task<int> GetTotalCurrentOccupancyAsync(CancellationToken cancellationToken = default);
    Task<int> GetFullHousingsCount(CancellationToken cancellationToken = default);
}
