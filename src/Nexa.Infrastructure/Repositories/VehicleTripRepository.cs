using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;
using Nexa.Infrastructure.Persistence;
using Nexa.Infrastructure.Repositories.Base;

namespace Nexa.Infrastructure.Repositories;

public class VehicleTripRepository : BaseRepository<VehicleTrip>, IVehicleTripRepository
{
    public VehicleTripRepository(AppDbContext context) : base(context)
    {
    }
}
