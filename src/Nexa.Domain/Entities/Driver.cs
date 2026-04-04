namespace Nexa.Domain.Entities;

public class Driver : Entity
{
    public long UserId { get; set; }
    public string LicenseNumber { get; set; } = string.Empty;
    public DateTime LicenseExpiration { get; set; }
    public string LicenseType { get; set; } = string.Empty;
    public long? VehicleId { get; set; }

    #region Navigation Properties
    public User? User { get; set; }
    public Vehicle? Vehicle { get; set; }
    #endregion
}
