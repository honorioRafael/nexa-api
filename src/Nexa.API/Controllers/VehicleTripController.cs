using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

public class VehicleTripController : BaseController<VehicleTrip, IVehicleTripService, VehicleTripDto, CreateVehicleTripDto, UpdateVehicleTripDto>
{
    public VehicleTripController(IVehicleTripService vehicleTripService) : base(vehicleTripService) { }


    [HttpGet("GetLastByVehicleId/{vehicleId}")]
    public virtual async Task<IActionResult> GetLastByVehicleIdAsync(long vehicleId, CancellationToken cancellationToken)
    {
        var result = await _service.GetLastByVehicleIdAsync(vehicleId, cancellationToken);
        return result.Match(
            entity => Ok(MapToDto(entity)),
            HandleErrors);
    }

    [HttpGet("GetByHousingId/{housingId}")]
    public async Task<IActionResult> GetByHousingId(long housingId, CancellationToken cancellationToken)
    {
        var result = await _service.GetByHousingIdAsync(housingId, cancellationToken);
        return result.Match(
            dtos => Ok(dtos),
            HandleErrors);
    }
}

