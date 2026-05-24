using Nexa.Domain.Enums;

namespace Nexa.Domain.Entities;

public class Employee : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime HireDate { get; set; }
    public EmployeeStatus Status { get; set; }
    public long? HousingId { get; set; }

    #region Navigation Properties
    public Housing? Housing { get; set; }
    #endregion
}
