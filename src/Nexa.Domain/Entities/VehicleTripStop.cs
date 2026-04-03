namespace Nexa.Domain.Entities;

public class VehicleTripStop : Entity
{
    public long VehicleTripId { get; set; }
    public VehicleTrip? VehicleTrip { get; set; }

    public string Description { get; set; } = string.Empty;

    public long AddressId { get; set; }
    public Address? Address { get; set; }

    public int QueuePosition { get; set; }
}
