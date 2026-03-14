using Nexa.Domain.Enums;

namespace Nexa.Domain.Entities;

public class VehicleModel : Entity
{
    public string Manufacturer { get; set; } = string.Empty;
    public VehicleType Type { get; set; }
    public int Year { get; set; }
    public FuelType FuelType { get; set; }
    public int MaxCapacity { get; set; }
}
