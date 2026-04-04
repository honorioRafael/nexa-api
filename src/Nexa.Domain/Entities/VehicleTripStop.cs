namespace Nexa.Domain.Entities;

public class VehicleTripStop : Entity
{
    public long VehicleTripId { get; set; }
    public long AddressId { get; set; }
    public string Description { get; set; } = string.Empty;
    public int QueuePosition { get; set; }

    #region Navigation Properties
    public VehicleTrip? VehicleTrip { get; set; }
    public Address? Address { get; set; }
    #endregion
}
