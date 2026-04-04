namespace Nexa.Domain.Entities;

public class HousingAllocation : Entity
{
    public long EmployeeId { get; set; }
    public long HousingId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime? CheckOutDate { get; set; }
    public long? HousingRoomId { get; set; }

    #region Navigation Properties
    public Employee? Employee { get; set; }
    public Housing? Housing { get; set; }
    public HousingRoom? HousingRoom { get; set; }
    #endregion
}
