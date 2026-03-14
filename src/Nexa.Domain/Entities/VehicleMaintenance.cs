namespace Nexa.Domain.Entities;

public class VehicleMaintenance : Entity
{
    public long VehicleId { get; set; }
    public Vehicle? Vehicle { get; set; }

    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal Cost { get; set; }
}
