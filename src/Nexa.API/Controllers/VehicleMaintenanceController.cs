using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

public class VehicleMaintenanceController : BaseController<VehicleMaintenance, IVehicleMaintenanceService, VehicleMaintenanceDto, CreateVehicleMaintenanceDto, UpdateVehicleMaintenanceDto>
{
    public VehicleMaintenanceController(IVehicleMaintenanceService vehicleMaintenanceService) : base(vehicleMaintenanceService) { }


}

