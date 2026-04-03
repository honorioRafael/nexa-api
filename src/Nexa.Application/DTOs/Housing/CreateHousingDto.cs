using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record CreateHousingDto(string Name, long AddressId, string City, string ZipCode, int MaxCapacity, int CurrentCapacity, HousingStatus Status, bool UseHousingRoom);
