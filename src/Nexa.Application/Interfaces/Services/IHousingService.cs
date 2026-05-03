using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services.Base;
using Nexa.Domain.Entities;

namespace Nexa.Application.Interfaces.Services;

public interface IHousingService : IBaseService<Housing, CreateHousingDto, UpdateHousingDto>
{
    Task<HousingDto?> GetByIdWithOccupancyAsync(long id, CancellationToken cancellationToken = default);
    Task<List<HousingDto>> GetAllWithOccupancyAsync(CancellationToken cancellationToken = default);
}
