using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record VehicleDto(long Id, string LicensePlate, long VehicleModelId, string ChassisNumber, int Mileage, VehicleStatus Status, VehicleCondition VehicleCondition, string? OriginCountry)
{
    public static implicit operator VehicleDto(Nexa.Domain.Entities.Vehicle entity) =>
        new(entity.Id, entity.LicensePlate, entity.VehicleModelId, entity.ChassisNumber, entity.Mileage, entity.Status, entity.VehicleCondition, entity.OriginCountry);
}
