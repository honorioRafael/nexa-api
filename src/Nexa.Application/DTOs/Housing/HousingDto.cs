using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record HousingDto(long Id, string Name, long AddressId, string City, string ZipCode, int MaxCapacity, int CurrentCapacity, HousingStatus Status, bool UseHousingRoom)
{
    public static implicit operator HousingDto(Nexa.Domain.Entities.Housing entity) =>
        new(entity.Id, entity.Name, entity.AddressId, entity.City, entity.ZipCode, entity.MaxCapacity, entity.CurrentCapacity, entity.Status, entity.UseHousingRoom);
}
