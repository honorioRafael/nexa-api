using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class HousingAllocationService : BaseService<HousingAllocation, IHousingAllocationRepository, CreateHousingAllocationDto, UpdateHousingAllocationDto>, IHousingAllocationService
{
    public HousingAllocationService(IHousingAllocationRepository repository) : base(repository)
    {
    }

    public async Task<List<HousingAllocationDto>> GetByHousingIdAsync(long housingId, CancellationToken cancellationToken = default)
    {
        var entities = await _repository.GetByHousingIdAsync(housingId, cancellationToken);
        return entities.Select(e => (HousingAllocationDto)e!).ToList();
    }
}
