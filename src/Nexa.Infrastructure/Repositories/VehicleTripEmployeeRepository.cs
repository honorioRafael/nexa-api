using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;
using Nexa.Infrastructure.Persistence;
using Nexa.Infrastructure.Repositories.Base;

namespace Nexa.Infrastructure.Repositories;

public class VehicleTripEmployeeRepository : BaseRepository<VehicleTripEmployee>, IVehicleTripEmployeeRepository
{
    public VehicleTripEmployeeRepository(AppDbContext context) : base(context) { }
}
