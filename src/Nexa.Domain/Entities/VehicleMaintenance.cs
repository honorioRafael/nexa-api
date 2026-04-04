namespace Nexa.Domain.Entities;

public class VehicleMaintenance : Entity
{
    public long VehicleId { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal Cost { get; set; }
    public DateTime? LastReviewDate { get; set; }
    public decimal? LastReviewMileage { get; set; }

    #region Navigation Properties
    public Vehicle? Vehicle { get; set; }
    #endregion
}
