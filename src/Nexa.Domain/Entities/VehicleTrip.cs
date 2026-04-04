using Nexa.Domain.Enums;

namespace Nexa.Domain.Entities;

public class VehicleTrip : Entity
{
    public long DriverId { get; set; }
    public Driver? Driver { get; set; }
    public long VehicleId { get; set; }
    public Vehicle? Vehicle { get; set; }
    public long OriginAddressId { get; set; }
    public Address? OriginAddress { get; set; }
    public long DestinationAddressId { get; set; }
    public Address? DestinationAddress { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public VehicleTripStatus Status { get; set; }
    public decimal Distance { get; set; }

    public string Description { get; set; } = string.Empty;
    public int CurrentOcupation { get; set; }

    public List<VehicleTripEmployee> ListVehicleTripEmployee { get; set; } = new();
    public List<VehicleTripStop> ListVehicleTripStop { get; set; } = new();
}
