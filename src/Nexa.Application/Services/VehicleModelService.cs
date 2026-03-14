using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class VehicleModelService : BaseService<VehicleModel, IVehicleModelRepository>, IVehicleModelService
{
    public VehicleModelService(IVehicleModelRepository repository) : base(repository)
    {
    }
}
