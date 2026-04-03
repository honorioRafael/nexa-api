using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record CreateHousingRoomDto(long HousingId, string Name, string? Description, int Capacity, HousingRoomType HousingRoomType);
