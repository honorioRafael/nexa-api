namespace Nexa.Application.DTOs;

public record VehicleMaintenanceDto(long Id, long VehicleId, string Description, DateTime StartDate, DateTime? EndDate, decimal Cost, DateTime? LastReviewDate, decimal? LastReviewMileage);
