namespace Nexa.Application.DTOs;

public record CreateVehicleMaintenanceDto(long VehicleId, string Description, DateTime StartDate, decimal Cost, DateTime? LastReviewDate, decimal? LastReviewMileage);
