using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record VehicleTripDto(long Id, long VehicleAllocationId, string Origin, string Destination, DateTime StartDate, DateTime? EndDate, VehicleTripStatus Status, decimal Distance);

public record CreateVehicleTripDto(long VehicleAllocationId, string Origin, string Destination, DateTime StartDate);

public record UpdateVehicleTripDto(DateTime? EndDate, VehicleTripStatus Status, decimal Distance);
