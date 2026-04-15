using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services.Base;
using Nexa.Domain.Entities;

namespace Nexa.Application.Interfaces.Services;

public interface IHousingAllocationService : IBaseService<HousingAllocation, CreateHousingAllocationDto, UpdateHousingAllocationDto>
{
    Task<List<HousingAllocationDto>> GetByHousingIdAsync(long housingId, CancellationToken cancellationToken = default);
}
