using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record VehicleDto(long Id, string LicensePlate, long VehicleModelId, string ChassisNumber, int Mileage, VehicleStatus Status, VehicleCondition VehicleCondition, string? OriginCountry);
