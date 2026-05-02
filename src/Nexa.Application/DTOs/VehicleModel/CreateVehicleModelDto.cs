using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record CreateVehicleModelDto(string Manufacturer, string Model, VehicleType Type, int Year, FuelType FuelType, int MaxCapacity);
