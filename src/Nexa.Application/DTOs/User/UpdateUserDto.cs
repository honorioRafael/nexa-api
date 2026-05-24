namespace Nexa.Application.DTOs;

public record UpdateUserDto(string FullName, string Role, DateTime HireDate, string PhoneNumber, string Cpf);
