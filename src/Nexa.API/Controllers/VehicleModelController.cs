using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleModelController : BaseController<VehicleModel, IVehicleModelService, VehicleModelDto, CreateVehicleModelDto, UpdateVehicleModelDto>
{
    public VehicleModelController(IVehicleModelService vehicleModelService) : base(vehicleModelService) { }

    protected override VehicleModelDto MapToDto(VehicleModel entity) =>
        new(entity.Id, entity.Manufacturer, entity.Type, entity.Year, entity.FuelType, entity.MaxCapacity);
}
