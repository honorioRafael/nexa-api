using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record UpdateHousingDto(string Name, long AddressId, int MaxCapacity, HousingType HousingType, bool UseHousingRoom);
