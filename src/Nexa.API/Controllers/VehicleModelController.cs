using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

[Route("api/vehicle-models")]
public class VehicleModelController : BaseController<VehicleModel, IVehicleModelService, VehicleModelDto, CreateVehicleModelDto, UpdateVehicleModelDto>
{
    public VehicleModelController(IVehicleModelService vehicleModelService) : base(vehicleModelService) { }


}

