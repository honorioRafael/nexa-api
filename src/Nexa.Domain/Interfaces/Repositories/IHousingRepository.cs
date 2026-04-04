using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories.Base;

namespace Nexa.Domain.Interfaces.Repositories;

public interface IHousingRepository : IBaseRepository<Housing>
{
    Task<(int MaxCapacity, int CurrentCapacity)> GetHomePageData(CancellationToken cancellationToken = default);
}