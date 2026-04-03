using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record HousingDto(long Id, string Name, long AddressId, string City, string ZipCode, int MaxCapacity, int CurrentCapacity, HousingStatus Status, bool UseHousingRoom);
