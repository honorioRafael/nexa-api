using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record UpdateVehicleDto(string LicensePlate, int Mileage, VehicleStatus Status, VehicleCondition VehicleCondition, string? OriginCountry);
