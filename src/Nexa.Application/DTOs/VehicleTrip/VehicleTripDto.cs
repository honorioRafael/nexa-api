using Nexa.Domain.Entities;
using Nexa.Domain.Enums;

namespace Nexa.Application.DTOs;

public record VehicleTripDto(long Id, long DriverId, long VehicleId, long OriginAddressId, long DestinationAddressId, DateTime StartDate, DateTime? EndDate, VehicleTripStatus Status, decimal Distance, string Description, int CurrentOcupation, VehicleDto? VehicleDto, AddressDto? OriginAddress, AddressDto? DestinationAddress, List<VehicleTripEmployeeDto> ListVehicleTripEmployee, List<VehicleTripStopDto> ListVehicleTripStop)
{
    public static implicit operator VehicleTripDto?(VehicleTrip? entity) =>
        entity is null ? null : new(entity.Id, entity.DriverId, entity.VehicleId, entity.OriginAddressId, entity.DestinationAddressId, entity.StartDate, entity.EndDate, entity.Status, entity.Distance, entity.Description, entity.CurrentOcupation,
            entity.Vehicle,
            entity.OriginAddress,
            entity.DestinationAddress,
            entity.ListVehicleTripEmployee?.Select(x => (VehicleTripEmployeeDto)x).ToList() ?? new(),
            entity.ListVehicleTripStop?.Select(x => (VehicleTripStopDto)x).ToList() ?? new());
}
