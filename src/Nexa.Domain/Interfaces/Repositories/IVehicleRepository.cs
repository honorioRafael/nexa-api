using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories.Base;
using Nexa.Domain.Models;

namespace Nexa.Domain.Interfaces.Repositories;

public interface IVehicleRepository : IBaseRepository<Vehicle>
{
    Task<HomePageVehicleStats> GetHomePageData(CancellationToken cancellationToken = default);
    Task<List<Vehicle>> GetAllWithModelAsync(CancellationToken cancellationToken = default);
    Task<Vehicle?> GetByLicensePlateAsync(string licensePlate, CancellationToken cancellationToken = default);
    Task<Vehicle?> GetByChassisNumberAsync(string chassisNumber, CancellationToken cancellationToken = default);
    Task<List<VehicleTripCount>> GetTopUtilizedVehiclesAsync(int limit, DateTime? startDate = null, DateTime? endDate = null, CancellationToken cancellationToken = default);
}