using Nexa.Domain.Entities;
using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record EmployeeDto(long Id, long UserId, string Name, string Cpf, string Role, string PhoneNumber, DateTime HireDate, EmployeeStatus Status, long? HousingId)
{
    public static implicit operator EmployeeDto?(Employee? entity) =>
        entity is null ? null : new(entity.Id, entity.UserId, entity.Name, entity.Cpf, entity.Role, entity.PhoneNumber, entity.HireDate, entity.Status, entity.HousingId);
}
