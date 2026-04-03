namespace Nexa.Domain.Entities;

public class VehicleTripEmployee : Entity
{
    public long VehicleTripId { get; set; }
    public VehicleTrip? VehicleTrip { get; set; }

    public long EmployeeId { get; set; }
    public Employee? Employee { get; set; }
}
