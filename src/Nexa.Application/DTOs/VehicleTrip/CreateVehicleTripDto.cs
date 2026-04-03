using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record CreateVehicleTripDto(long DriverId, long VehicleId, long OriginAddressId, long DestinationAddressId, DateTime StartDate, string Description);
