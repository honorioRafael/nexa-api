using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

[Route("api/vehicle-trip-stops")]
public class VehicleTripStopController : BaseController<VehicleTripStop, IVehicleTripStopService, VehicleTripStopDto, CreateVehicleTripStopDto, UpdateVehicleTripStopDto>
{
    public VehicleTripStopController(IVehicleTripStopService service) : base(service) { }


}

