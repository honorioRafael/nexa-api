using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleTripEmployeeController : BaseController<VehicleTripEmployee, IVehicleTripEmployeeService, VehicleTripEmployeeDto, CreateVehicleTripEmployeeDto, UpdateVehicleTripEmployeeDto>
{
    public VehicleTripEmployeeController(IVehicleTripEmployeeService service) : base(service) { }

    protected override VehicleTripEmployeeDto MapToDto(VehicleTripEmployee entity) =>
        new(entity.Id, entity.VehicleTripId, entity.EmployeeId);
}
