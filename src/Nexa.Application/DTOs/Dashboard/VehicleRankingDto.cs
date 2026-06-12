namespace Nexa.Application.DTOs.Dashboard;

public record VehicleRankingDto(long VehicleId, string LicensePlate, string ModelName, int TripCount, double Percentage);
