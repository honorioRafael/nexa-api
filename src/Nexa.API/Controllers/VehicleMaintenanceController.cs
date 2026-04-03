using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleMaintenanceController : BaseController<VehicleMaintenance, IVehicleMaintenanceService, VehicleMaintenanceDto, CreateVehicleMaintenanceDto, UpdateVehicleMaintenanceDto>
{
    public VehicleMaintenanceController(IVehicleMaintenanceService vehicleMaintenanceService) : base(vehicleMaintenanceService) { }

    protected override VehicleMaintenanceDto MapToDto(VehicleMaintenance entity) =>
        new(entity.Id, entity.VehicleId, entity.Description, entity.StartDate, entity.EndDate, entity.Cost);
}
