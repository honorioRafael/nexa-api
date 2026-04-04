using Nexa.Domain.Enums;

namespace Nexa.Domain.Entities;

public class Housing : Entity
{
    public string Name { get; set; } = string.Empty;
    public long AddressId { get; set; }
    public string City { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public int MaxCapacity { get; set; }
    public int CurrentCapacity { get; set; }
    public HousingStatus Status { get; set; }
    public bool UseHousingRoom { get; set; }

    #region Navigation Properties
    public Address? Address { get; set; }
    #endregion
}
