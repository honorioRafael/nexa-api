namespace Nexa.Application.DTOs;

public record VehicleTripStopDto(long Id, long VehicleTripId, string Description, long AddressId, int QueuePosition)
{
    public static implicit operator VehicleTripStopDto(Nexa.Domain.Entities.VehicleTripStop entity) =>
        new(entity.Id, entity.VehicleTripId, entity.Description, entity.AddressId, entity.QueuePosition);
}
