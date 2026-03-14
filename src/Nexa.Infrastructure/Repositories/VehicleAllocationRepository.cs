using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;
using Nexa.Infrastructure.Persistence;
using Nexa.Infrastructure.Repositories.Base;

namespace Nexa.Infrastructure.Repositories;

public class VehicleAllocationRepository : BaseRepository<VehicleAllocation>, IVehicleAllocationRepository
{
    public VehicleAllocationRepository(AppDbContext context) : base(context)
    {
    }
}
