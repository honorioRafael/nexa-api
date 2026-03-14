using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;
using Nexa.Infrastructure.Persistence;
using Nexa.Infrastructure.Repositories.Base;

namespace Nexa.Infrastructure.Repositories;

public class HousingAllocationRepository : BaseRepository<HousingAllocation>, IHousingAllocationRepository
{
    public HousingAllocationRepository(AppDbContext context) : base(context)
    {
    }
}
