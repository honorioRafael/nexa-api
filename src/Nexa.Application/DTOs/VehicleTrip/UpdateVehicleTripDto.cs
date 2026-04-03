using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record UpdateVehicleTripDto(DateTime? EndDate, VehicleTripStatus Status, decimal Distance, string Description);
