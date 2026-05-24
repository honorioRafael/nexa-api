using Nexa.Domain.Entities;

namespace Nexa.Application.DTOs;

public record UserDto(long Id, string Email, string FullName, string Role, DateTime HireDate, string PhoneNumber, string Cpf, DateTime LastPasswordChange)
{
    public static implicit operator UserDto?(User? entity) =>
        entity is null ? null : new(entity.Id, entity.Email, entity.FullName, entity.Role, entity.HireDate, entity.PhoneNumber, entity.Cpf, entity.LastPasswordChange);
}
