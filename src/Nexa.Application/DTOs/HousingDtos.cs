using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record HousingDto(long Id, string Name, string Address, string City, string ZipCode, int MaxCapacity, int CurrentCapacity, HousingStatus Status);

public record CreateHousingDto(string Name, string Address, string City, string ZipCode, int MaxCapacity, int CurrentCapacity, HousingStatus Status);

public record UpdateHousingDto(string Name, string Address, string City, string ZipCode, int MaxCapacity, int CurrentCapacity, HousingStatus Status);
