namespace Nexa.Application.DTOs;

public record MovementDashboardDto(
    int HousingTransfersCount,
    int HousingCheckInsCount,
    int HousingCheckOutsCount,
    int StatusChangesCount,
    int VehicleTripsCount,
    List<MovementDto> Items,
    int TotalItems,
    int Page,
    int PageSize);
