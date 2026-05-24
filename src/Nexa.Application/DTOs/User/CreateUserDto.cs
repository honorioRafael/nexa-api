namespace Nexa.Application.DTOs;

public record CreateUserDto(string Email, string Password, string FullName, string Role, DateTime HireDate, string PhoneNumber, string Cpf);
