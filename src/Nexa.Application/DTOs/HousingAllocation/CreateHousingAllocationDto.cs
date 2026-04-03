namespace Nexa.Application.DTOs;

public record CreateHousingAllocationDto(long EmployeeId, long HousingId, DateTime CheckInDate, DateTime? CheckOutDate, long? HousingRoomId);
