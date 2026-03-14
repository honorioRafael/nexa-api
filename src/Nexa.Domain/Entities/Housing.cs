using Nexa.Domain.Enums;

namespace Nexa.Domain.Entities;

public class Housing : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public int MaxCapacity { get; set; }
    public int CurrentCapacity { get; set; }
    public HousingStatus Status { get; set; }
}
