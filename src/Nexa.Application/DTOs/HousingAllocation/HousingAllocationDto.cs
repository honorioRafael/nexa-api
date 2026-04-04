using Nexa.Domain.Entities;

namespace Nexa.Application.DTOs;

public record HousingAllocationDto(long Id, long EmployeeId, long HousingId, DateTime CheckInDate, DateTime? CheckOutDate, long? HousingRoomId)
{
    public static implicit operator HousingAllocationDto?(HousingAllocation? entity) =>
        entity is null ? null : new(entity.Id, entity.EmployeeId, entity.HousingId, entity.CheckInDate, entity.CheckOutDate, entity.HousingRoomId);
}
