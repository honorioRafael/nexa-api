namespace Nexa.Application.DTOs;

public record HousingAllocationDto(long Id, long EmployeeId, long HousingId, DateTime CheckInDate, DateTime? CheckOutDate);

public record CreateHousingAllocationDto(long EmployeeId, long HousingId, DateTime CheckInDate, DateTime? CheckOutDate);

public record UpdateHousingAllocationDto(DateTime? CheckOutDate);
