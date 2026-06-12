using Nexa.Application.DTOs.Dashboard;

namespace Nexa.Application.Interfaces.Services;

public interface IDashboardService
{
    Task<List<OccupancyEvolutionDto>> GetOccupancyEvolutionAsync(DateTime? startDate = null, DateTime? endDate = null, CancellationToken cancellationToken = default);
    Task<List<VehicleRankingDto>> GetVehicleRankingAsync(DateTime? startDate = null, DateTime? endDate = null, CancellationToken cancellationToken = default);
}
