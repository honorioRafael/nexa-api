using Nexa.Domain.Entities;

namespace Nexa.Application.DTOs;

public record VehicleMaintenanceDto(long Id, long VehicleId, string Description, DateTime StartDate, DateTime? EndDate, decimal Cost, DateTime? LastReviewDate, decimal? LastReviewMileage)
{
    public static implicit operator VehicleMaintenanceDto?(VehicleMaintenance? entity) =>
        entity is null ? null : new(entity.Id, entity.VehicleId, entity.Description, entity.StartDate, entity.EndDate, entity.Cost, entity.LastReviewDate, entity.LastReviewMileage);
}
