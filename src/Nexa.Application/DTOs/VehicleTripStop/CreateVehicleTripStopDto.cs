namespace Nexa.Application.DTOs;

public record CreateVehicleTripStopDto(long VehicleTripId, string Description, long AddressId, int QueuePosition);
