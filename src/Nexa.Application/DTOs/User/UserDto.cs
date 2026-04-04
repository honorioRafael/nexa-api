using Nexa.Domain.Entities;

namespace Nexa.Application.DTOs;

public record UserDto(long Id, string Email)
{
    public static implicit operator UserDto?(User? entity) =>
        entity is null ? null : new(entity.Id, entity.Email);
}
