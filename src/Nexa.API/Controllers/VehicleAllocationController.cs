using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleAllocationController : BaseController<VehicleAllocation, IVehicleAllocationService, VehicleAllocationDto, CreateVehicleAllocationDto, UpdateVehicleAllocationDto>
{
    public VehicleAllocationController(IVehicleAllocationService vehicleAllocationService) : base(vehicleAllocationService) { }

    protected override VehicleAllocationDto MapToDto(VehicleAllocation entity) =>
        new(entity.Id, entity.DriverId, entity.VehicleId, entity.StartDate, entity.EndDate);
}
