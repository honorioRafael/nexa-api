namespace Nexa.Application.DTOs;

public record UserDto(long Id, string Email)
{
    public static implicit operator UserDto(Nexa.Domain.Entities.User entity) =>
        new(entity.Id, entity.Email);
}
