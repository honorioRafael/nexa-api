using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record UpdateHousingRoomDto(string Name, string? Description, int Capacity, HousingRoomType HousingRoomType);
