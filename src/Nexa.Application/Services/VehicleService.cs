using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class VehicleService : BaseService<Vehicle, IVehicleRepository>, IVehicleService
{
    public VehicleService(IVehicleRepository repository) : base(repository)
    {
    }
}
