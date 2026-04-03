using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record VehicleTripDto(long Id, long DriverId, long VehicleId, long OriginAddressId, long DestinationAddressId, DateTime StartDate, DateTime? EndDate, VehicleTripStatus Status, decimal Distance, string Description, int CurrentOcupation);
