namespace Nexa.Application.DTOs;

public record VehicleMaintenanceDto(long Id, long VehicleId, string Description, DateTime StartDate, DateTime? EndDate, decimal Cost);

public record CreateVehicleMaintenanceDto(long VehicleId, string Description, DateTime StartDate, decimal Cost);

public record UpdateVehicleMaintenanceDto(string Description, DateTime? EndDate, decimal Cost);
