using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class VehicleTripStopService : BaseService<VehicleTripStop, IVehicleTripStopRepository, CreateVehicleTripStopDto, UpdateVehicleTripStopDto>, IVehicleTripStopService
{
    public VehicleTripStopService(IVehicleTripStopRepository repository) : base(repository) { }
}
