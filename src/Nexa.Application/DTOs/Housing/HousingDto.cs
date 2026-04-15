using Nexa.Domain.Entities;
using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record HousingDto(long Id, string Name, long AddressId, int MaxCapacity, int CurrentCapacity, HousingStatus HousingStatus, HousingType HousingType, bool UseHousingRoom, AddressDto? Address)
{
    public static implicit operator HousingDto?(Housing? entity) =>
        entity is null ? null : new(entity.Id, entity.Name, entity.AddressId, entity.MaxCapacity, entity.CurrentCapacity, entity.HousingStatus, entity.HousingType, entity.UseHousingRoom, entity.Address);
}
