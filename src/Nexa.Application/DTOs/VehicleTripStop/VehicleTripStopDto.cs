namespace Nexa.Application.DTOs;

public record VehicleTripStopDto(long Id, long VehicleTripId, string Description, long AddressId, int QueuePosition);
