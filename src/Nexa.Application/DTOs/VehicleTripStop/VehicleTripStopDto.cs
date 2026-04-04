using Nexa.Domain.Entities;

namespace Nexa.Application.DTOs;

public record VehicleTripStopDto(long Id, long VehicleTripId, string Description, long AddressId, int QueuePosition)
{
    public static implicit operator VehicleTripStopDto?(VehicleTripStop? entity) =>
        entity is null ? null : new(entity.Id, entity.VehicleTripId, entity.Description, entity.AddressId, entity.QueuePosition);
}
