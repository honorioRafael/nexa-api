using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class VehicleTripService : BaseService<VehicleTrip, IVehicleTripRepository>, IVehicleTripService
{
    public VehicleTripService(IVehicleTripRepository repository) : base(repository)
    {
    }
}
