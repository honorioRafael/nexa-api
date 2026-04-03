namespace Nexa.Application.DTOs;

public record UpdateDriverDto(string LicenseNumber, DateTime LicenseExpiration, string LicenseType, long? VehicleId);
