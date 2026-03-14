using Nexa.Domain.Enums;

namespace Nexa.Domain.Entities;

public class Vehicle : Entity
{
    public string LicensePlate { get; set; } = string.Empty;

    public long VehicleModelId { get; set; }
    public VehicleModel? VehicleModel { get; set; }

    public string ChassisNumber { get; set; } = string.Empty;
    public int Mileage { get; set; }
    public VehicleStatus Status { get; set; }
}
