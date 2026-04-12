using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record UpdateEmployeeDto(string Name, string Cpf, string Role, string PhoneNumber, DateTime HireDate, EmployeeStatus Status);
