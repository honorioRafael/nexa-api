using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class VehicleMaintenanceService : BaseService<VehicleMaintenance, IVehicleMaintenanceRepository, CreateVehicleMaintenanceDto, UpdateVehicleMaintenanceDto>, IVehicleMaintenanceService
{
    public VehicleMaintenanceService(IVehicleMaintenanceRepository repository) : base(repository)
    {
    }
}
