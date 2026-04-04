namespace Nexa.Domain.Entities;

public class VehicleTripEmployee : Entity
{
    public long VehicleTripId { get; set; }
    public long EmployeeId { get; set; }

    #region Navigation Properties
    public VehicleTrip? VehicleTrip { get; set; }
    public Employee? Employee { get; set; }
    #endregion
}
