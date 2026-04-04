using Nexa.Domain.Entities;

namespace Nexa.Application.DTOs;

public record AddressDto(long Id, string Name, string Street, string Number, string? Complement, string Neighborhood, string City, string State, string Country, string ZipCode)
{
    public static implicit operator AddressDto?(Address? entity) =>
        entity is null ? null : new(entity.Id, entity.Name, entity.Street, entity.Number, entity.Complement, entity.Neighborhood, entity.City, entity.State, entity.Country, entity.ZipCode);
}
