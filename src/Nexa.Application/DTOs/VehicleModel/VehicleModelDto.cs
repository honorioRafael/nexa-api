using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record VehicleModelDto(long Id, string Manufacturer, VehicleType Type, int Year, FuelType FuelType, int MaxCapacity);
