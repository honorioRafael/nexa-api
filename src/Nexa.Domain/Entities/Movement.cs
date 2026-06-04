using Nexa.Domain.Enums;

namespace Nexa.Domain.Entities;

public class Movement : Entity
{
    public MovementType Type { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string StatusLabel { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    #region Navigation Properties
    public long? EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    public long? VehicleId { get; set; }
    public Vehicle? Vehicle { get; set; }

    public long? HousingId { get; set; }
    public Housing? Housing { get; set; }
    #endregion
}
