using Nexa.Domain.Enums;

namespace Nexa.Domain.Entities;

public class VehicleTrip : Entity
{
    public long VehicleAllocationId { get; set; }
    public VehicleAllocation? VehicleAllocation { get; set; }

    public string Origin { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public VehicleTripStatus Status { get; set; }
    public decimal Distance { get; set; }
}
