using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record EmployeeDto(long Id, long UserId, string Name, string Cpf, string Role, string PhoneNumber, DateTime HireDate, EmployeeStatus Status, long? HousingId);
