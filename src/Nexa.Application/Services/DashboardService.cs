using Nexa.Application.DTOs.Dashboard;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class DashboardService(
    IHousingAllocationRepository housingAllocationRepository,
    IHousingRepository housingRepository,
    IVehicleRepository vehicleRepository,
    IVehicleTripRepository vehicleTripRepository) : IDashboardService
{
    private static DateTime EnsureUtc(DateTime dt)
    {
        return dt.Kind == DateTimeKind.Unspecified
            ? DateTime.SpecifyKind(dt, DateTimeKind.Utc)
            : dt.ToUniversalTime();
    }

    public async Task<List<OccupancyEvolutionDto>> GetOccupancyEvolutionAsync(
        DateTime? startDate = null,
        DateTime? endDate = null,
        CancellationToken cancellationToken = default)
    {
        var end = endDate.HasValue ? EnsureUtc(endDate.Value) : DateTime.UtcNow;
        var start = startDate.HasValue ? EnsureUtc(startDate.Value) : end.AddDays(-30);

        var allocations = await housingAllocationRepository.GetAllocationsInPeriodAsync(start, end, cancellationToken);
        var maxCapacity = await housingRepository.GetMaxCapacityAsync(cancellationToken);

        var list = new List<OccupancyEvolutionDto>();
        var culture = new System.Globalization.CultureInfo("pt-BR");

        for (var date = start.Date; date <= end.Date; date = date.AddDays(1))
        {
            var activeCount = allocations.Count(a =>
                a.CheckInDate.Date <= date &&
                (a.CheckOutDate == null || a.CheckOutDate.Value.Date >= date));

            double rate = maxCapacity == 0 ? 0 : ((double)activeCount / maxCapacity) * 100;

            var day = date.Day.ToString("D2");
            var monthName = date.ToString("MMM", culture).Replace(".", "").Trim();
            if (monthName.StartsWith("de ", StringComparison.OrdinalIgnoreCase))
            {
                monthName = monthName.Substring(3).Trim();
            }
            var dateLabel = $"{day} {culture.TextInfo.ToTitleCase(monthName)}";

            list.Add(new OccupancyEvolutionDto(dateLabel, activeCount, Math.Round(rate, 2)));
        }

        return list;
    }

    public async Task<List<VehicleRankingDto>> GetVehicleRankingAsync(
        DateTime? startDate = null,
        DateTime? endDate = null,
        CancellationToken cancellationToken = default)
    {
        var startUtc = startDate.HasValue ? EnsureUtc(startDate.Value) : (DateTime?)null;
        var endUtc = endDate.HasValue ? EnsureUtc(endDate.Value) : (DateTime?)null;

        var topVehicles = await vehicleRepository.GetTopUtilizedVehiclesAsync(5, startUtc, endUtc, cancellationToken);
        var totalTrips = await vehicleTripRepository.GetTotalTripsCountAsync(startUtc, endUtc, cancellationToken);

        return topVehicles.Select(tv =>
        {
            var modelName = tv.Vehicle.VehicleModel != null
                ? $"{tv.Vehicle.VehicleModel.Manufacturer} {tv.Vehicle.VehicleModel.Model}"
                : "Desconhecido";

            double percentage = totalTrips == 0 ? 0 : ((double)tv.TripCount / totalTrips) * 100;

            return new VehicleRankingDto(
                tv.Vehicle.Id,
                tv.Vehicle.LicensePlate,
                modelName,
                tv.TripCount,
                Math.Round(percentage, 2)
            );
        }).ToList();
    }
}
