using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleController : BaseController<Vehicle, IVehicleService, VehicleDto, CreateVehicleDto, UpdateVehicleDto>
{
    public VehicleController(IVehicleService vehicleService) : base(vehicleService) { }


}
