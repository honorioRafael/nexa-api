namespace Nexa.Domain.Entities;

public class VehicleAllocation : Entity
{
    public long DriverId { get; set; }
    public Driver? Driver { get; set; }

    public long VehicleId { get; set; }
    public Vehicle? Vehicle { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
