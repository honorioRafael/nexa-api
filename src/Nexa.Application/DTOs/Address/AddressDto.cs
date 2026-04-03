namespace Nexa.Application.DTOs;

public record AddressDto(long Id, string Name, string Street, string Number, string? Complement, string Neighborhood, string City, string State, string Country, string ZipCode);
