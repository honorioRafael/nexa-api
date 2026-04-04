using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record HousingRoomDto(long Id, long HousingId, string Name, string? Description, int Capacity, HousingRoomType HousingRoomType)
{
    public static implicit operator HousingRoomDto(Nexa.Domain.Entities.HousingRoom entity) =>
        new(entity.Id, entity.HousingId, entity.Name, entity.Description, entity.Capacity, entity.HousingRoomType);
}
