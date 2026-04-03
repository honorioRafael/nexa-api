namespace Nexa.Application.DTOs;

public record UpdateVehicleMaintenanceDto(string Description, DateTime? EndDate, decimal Cost, DateTime? LastReviewDate, decimal? LastReviewMileage);
