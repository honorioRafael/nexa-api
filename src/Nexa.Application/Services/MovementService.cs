using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Enums;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class MovementService(IMovementRepository movementRepository) : IMovementService
{
    public async Task<MovementDashboardDto> GetDashboardAsync(
        string? search,
        List<MovementType>? types,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default)
    {
        var (items, totalCount) = await movementRepository.GetPagedAndFilteredAsync(search, types, page, pageSize, cancellationToken);
        var counts = await movementRepository.GetCountsAsync(cancellationToken);

        var dtoList = items.Select(x => (MovementDto)x!).ToList();

        int housingTransfers = counts.GetValueOrDefault(MovementType.HousingTransfer, 0);
        int housingCheckIns = counts.GetValueOrDefault(MovementType.HousingCheckIn, 0);
        int housingCheckOuts = counts.GetValueOrDefault(MovementType.HousingCheckOut, 0);
        int statusChanges = counts.GetValueOrDefault(MovementType.EmployeeStatusChange, 0);
        int vehicleTrips = counts.GetValueOrDefault(MovementType.VehicleTripStarted, 0) +
                           counts.GetValueOrDefault(MovementType.VehicleTripCompleted, 0);

        return new MovementDashboardDto(
            housingTransfers,
            housingCheckIns,
            housingCheckOuts,
            statusChanges,
            vehicleTrips,
            dtoList,
            totalCount,
            page,
            pageSize);
    }
}
