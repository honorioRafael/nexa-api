using Nexa.Application.DTOs;
using Nexa.Domain.Enums;

namespace Nexa.Application.Interfaces.Services;

public interface IMovementService
{
    Task<MovementDashboardDto> GetDashboardAsync(
        string? search,
        List<MovementType>? types,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default);
}
