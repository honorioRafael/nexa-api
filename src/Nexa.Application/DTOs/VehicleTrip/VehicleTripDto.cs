using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record VehicleTripDto(long Id, long DriverId, long VehicleId, long OriginAddressId, long DestinationAddressId, DateTime StartDate, DateTime? EndDate, VehicleTripStatus Status, decimal Distance, string Description, int CurrentOcupation, List<VehicleTripEmployeeDto> ListVehicleTripEmployee, List<VehicleTripStopDto> ListVehicleTripStop)
{
    public static implicit operator VehicleTripDto(Nexa.Domain.Entities.VehicleTrip entity) =>
        new(entity.Id, entity.DriverId, entity.VehicleId, entity.OriginAddressId, entity.DestinationAddressId, entity.StartDate, entity.EndDate, entity.Status, entity.Distance, entity.Description, entity.CurrentOcupation,
            entity.ListVehicleTripEmployee?.Select(x => (VehicleTripEmployeeDto)x).ToList() ?? new(),
            entity.ListVehicleTripStop?.Select(x => (VehicleTripStopDto)x).ToList() ?? new());
}
