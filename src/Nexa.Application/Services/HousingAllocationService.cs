using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class HousingAllocationService : BaseService<HousingAllocation, IHousingAllocationRepository>, IHousingAllocationService
{
    public HousingAllocationService(IHousingAllocationRepository repository) : base(repository)
    {
    }
}
