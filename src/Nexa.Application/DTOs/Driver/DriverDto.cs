using Nexa.Domain.Entities;

namespace Nexa.Application.DTOs;

public record DriverDto(long Id, long UserId, string LicenseNumber, DateTime LicenseExpiration, string LicenseType, long? VehicleId)
{
    public static implicit operator DriverDto?(Driver? entity) =>
        entity is null ? null : new(entity.Id, entity.UserId, entity.LicenseNumber, entity.LicenseExpiration, entity.LicenseType, entity.VehicleId);
}
