using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record UpdateVehicleModelDto(string Manufacturer, string Model, VehicleType Type, int Year, FuelType FuelType, int MaxCapacity);
