namespace Nexa.Application.DTOs;

public record CreateDriverDto(long UserId, string LicenseNumber, DateTime LicenseExpiration, string LicenseType, long? VehicleId);
