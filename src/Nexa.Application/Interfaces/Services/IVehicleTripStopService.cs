using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services.Base;
using Nexa.Domain.Entities;

namespace Nexa.Application.Interfaces.Services;

public interface IVehicleTripStopService : IBaseService<VehicleTripStop, CreateVehicleTripStopDto, UpdateVehicleTripStopDto>
{
}
