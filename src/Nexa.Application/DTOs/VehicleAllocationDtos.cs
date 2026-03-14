namespace Nexa.Application.DTOs;

public record VehicleAllocationDto(long Id, long DriverId, long VehicleId, DateTime StartDate, DateTime? EndDate);

public record CreateVehicleAllocationDto(long DriverId, long VehicleId, DateTime StartDate, DateTime? EndDate);

public record UpdateVehicleAllocationDto(DateTime? EndDate);
