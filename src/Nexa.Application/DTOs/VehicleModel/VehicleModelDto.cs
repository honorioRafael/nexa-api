using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record VehicleModelDto(long Id, string Manufacturer, VehicleType Type, int Year, FuelType FuelType, int MaxCapacity)
{
    public static implicit operator VehicleModelDto(Nexa.Domain.Entities.VehicleModel entity) =>
        new(entity.Id, entity.Manufacturer, entity.Type, entity.Year, entity.FuelType, entity.MaxCapacity);
}
