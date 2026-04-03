using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record CreateVehicleModelDto(string Manufacturer, VehicleType Type, int Year, FuelType FuelType, int MaxCapacity);
