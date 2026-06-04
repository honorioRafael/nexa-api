using Nexa.Domain.Entities;
using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record MovementDto(
    long Id,
    MovementType Type,
    string Title,
    string Description,
    string StatusLabel,
    DateTime CreatedAt,
    long? EmployeeId,
    long? VehicleId,
    long? HousingId)
{
    public static implicit operator MovementDto?(Movement? entity) =>
        entity is null ? null : new(
            entity.Id,
            entity.Type,
            entity.Title,
            entity.Description,
            entity.StatusLabel,
            entity.CreatedAt,
            entity.EmployeeId,
            entity.VehicleId,
            entity.HousingId);
}
