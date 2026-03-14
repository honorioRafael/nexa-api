namespace Nexa.Application.DTOs;

public record UserDto(long Id, string Email);

public record CreateUserDto(string Email, string Password);

public record UpdateUserDto(string Email, string Password);
