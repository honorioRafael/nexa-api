using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record VehicleDto(long Id, string LicensePlate, long VehicleModelId, string ChassisNumber, int Mileage, VehicleStatus Status);

public record CreateVehicleDto(string LicensePlate, long VehicleModelId, string ChassisNumber, int Mileage, VehicleStatus Status);

public record UpdateVehicleDto(string LicensePlate, int Mileage, VehicleStatus Status);
