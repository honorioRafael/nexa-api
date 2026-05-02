namespace Nexa.Application.DTOs;

public record CreateDriverDto(string LicenseNumber, DateTime LicenseExpiration, string LicenseType, long? VehicleId);
