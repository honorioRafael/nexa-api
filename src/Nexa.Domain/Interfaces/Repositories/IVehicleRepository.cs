using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories.Base;

namespace Nexa.Domain.Interfaces.Repositories;

public interface IVehicleRepository : IBaseRepository<Vehicle>
{
    Task<(int TotalVehicles, int AvailableVehicles)> GetHomePageData(CancellationToken cancellationToken = default);
}