using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record HousingRoomDto(long Id, long HousingId, string Name, string? Description, int Capacity, HousingRoomType HousingRoomType);
