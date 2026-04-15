using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories.Base;

namespace Nexa.Domain.Interfaces.Repositories;

public interface IHousingAllocationRepository : IBaseRepository<HousingAllocation>
{
    Task<List<HousingAllocation>> GetByHousingIdAsync(long housingId, CancellationToken cancellationToken = default);
}
