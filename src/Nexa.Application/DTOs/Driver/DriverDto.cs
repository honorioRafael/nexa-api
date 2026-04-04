namespace Nexa.Application.DTOs;

public record DriverDto(long Id, long UserId, string LicenseNumber, DateTime LicenseExpiration, string LicenseType, long? VehicleId)
{
    public static implicit operator DriverDto(Nexa.Domain.Entities.Driver entity) =>
        new(entity.Id, entity.UserId, entity.LicenseNumber, entity.LicenseExpiration, entity.LicenseType, entity.VehicleId);
}
