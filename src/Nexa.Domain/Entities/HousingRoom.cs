using Nexa.Domain.Enums;

namespace Nexa.Domain.Entities;

public class HousingRoom : Entity
{
    public long HousingId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int Capacity { get; set; }
    public HousingRoomType HousingRoomType { get; set; }

    #region Navigation Properties
    public Housing? Housing { get; set; }
    #endregion
}
