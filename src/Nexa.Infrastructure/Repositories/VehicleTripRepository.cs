using Microsoft.EntityFrameworkCore;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;
using Nexa.Infrastructure.Persistence;
using Nexa.Infrastructure.Repositories.Base;

namespace Nexa.Infrastructure.Repositories;

public class VehicleTripRepository : BaseRepository<VehicleTrip>, IVehicleTripRepository
{
    public VehicleTripRepository(AppDbContext context) : base(context) { }

    public async Task<VehicleTrip?> GetLastByVehicleIdAsync(long vehicleId, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(x => x.VehicleId == vehicleId)
            .Include(x => x.Vehicle)
                .ThenInclude(v => v!.VehicleModel)
            .Include(x => x.OriginAddress)
            .Include(x => x.DestinationAddress)
            .Include(x => x.ListVehicleTripEmployee)
                .ThenInclude(vte => vte.Employee)
            .Include(x => x.ListVehicleTripStop)
                .ThenInclude(vts => vts.Address)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<VehicleTrip>> GetByAddressIdAsync(long addressId, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(x => x.OriginAddressId == addressId || x.DestinationAddressId == addressId)
            .Include(x => x.Vehicle)
            .Include(x => x.ListVehicleTripEmployee)
                .ThenInclude(vte => vte.Employee)
            .ToListAsync(cancellationToken);
    }
}
