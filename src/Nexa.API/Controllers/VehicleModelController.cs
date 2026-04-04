using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

public class VehicleModelController : BaseController<VehicleModel, IVehicleModelService, VehicleModelDto, CreateVehicleModelDto, UpdateVehicleModelDto>
{
    public VehicleModelController(IVehicleModelService vehicleModelService) : base(vehicleModelService) { }


}

