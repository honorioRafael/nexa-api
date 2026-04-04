using Nexa.Domain.Entities;
using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record VehicleModelDto(long Id, string Manufacturer, VehicleType Type, int Year, FuelType FuelType, int MaxCapacity)
{
    public static implicit operator VehicleModelDto?(VehicleModel? entity) =>
        entity is null ? null : new(entity.Id, entity.Manufacturer, entity.Type, entity.Year, entity.FuelType, entity.MaxCapacity);
}
