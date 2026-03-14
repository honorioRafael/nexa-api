namespace Nexa.Application.DTOs;

public record DriverDto(long Id, long UserId, string LicenseNumber, DateTime LicenseExpiration, string LicenseType, long? VehicleId);

public record CreateDriverDto(long UserId, string LicenseNumber, DateTime LicenseExpiration, string LicenseType, long? VehicleId);

public record UpdateDriverDto(string LicenseNumber, DateTime LicenseExpiration, string LicenseType, long? VehicleId);
