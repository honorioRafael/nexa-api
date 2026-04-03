using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record UpdateEmployeeDto(string Name, string Role, string PhoneNumber, EmployeeStatus Status, long? HousingId);
