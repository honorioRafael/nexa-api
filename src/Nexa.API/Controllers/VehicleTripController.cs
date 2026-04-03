using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleTripController : BaseController<VehicleTrip, IVehicleTripService, VehicleTripDto, CreateVehicleTripDto, UpdateVehicleTripDto>
{
    public VehicleTripController(IVehicleTripService vehicleTripService) : base(vehicleTripService) { }

    protected override VehicleTripDto MapToDto(VehicleTrip entity) =>
        new(entity.Id, entity.VehicleAllocationId, entity.Origin, entity.Destination, entity.StartDate, entity.EndDate, entity.Status, entity.Distance);
}
