namespace Nexa.Application.DTOs;

public record VehicleTripEmployeeDto(long Id, long VehicleTripId, long EmployeeId, EmployeeDto? Employee)
{
    public static implicit operator VehicleTripEmployeeDto(Nexa.Domain.Entities.VehicleTripEmployee entity) =>
        new(entity.Id, entity.VehicleTripId, entity.EmployeeId, entity.Employee);
}
