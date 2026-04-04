using Nexa.Domain.Entities;

namespace Nexa.Application.DTOs;

public record VehicleTripEmployeeDto(long Id, long VehicleTripId, long EmployeeId, EmployeeDto? Employee)
{
    public static implicit operator VehicleTripEmployeeDto?(VehicleTripEmployee? entity) =>
        entity is null ? null : new(entity.Id, entity.VehicleTripId, entity.EmployeeId, entity.Employee);
}
