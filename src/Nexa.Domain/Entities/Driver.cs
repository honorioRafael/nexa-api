namespace Nexa.Domain.Entities;

public class Driver : Entity
{
    public string LicenseNumber { get; set; } = string.Empty;
    public DateTime LicenseExpiration { get; set; }
    public string LicenseType { get; set; } = string.Empty;
    public long? VehicleId { get; set; }

    #region Navigation Properties
    public Vehicle? Vehicle { get; set; }
    #endregion
}
