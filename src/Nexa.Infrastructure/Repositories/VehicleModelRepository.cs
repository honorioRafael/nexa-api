using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;
using Nexa.Infrastructure.Persistence;
using Nexa.Infrastructure.Repositories.Base;

namespace Nexa.Infrastructure.Repositories;

public class VehicleModelRepository : BaseRepository<VehicleModel>, IVehicleModelRepository
{
    public VehicleModelRepository(AppDbContext context) : base(context)
    {
    }
}
