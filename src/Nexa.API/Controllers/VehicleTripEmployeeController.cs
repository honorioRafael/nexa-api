using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

[Route("api/vehicle-trip-employees")]
public class VehicleTripEmployeeController : BaseController<VehicleTripEmployee, IVehicleTripEmployeeService, VehicleTripEmployeeDto, CreateVehicleTripEmployeeDto, UpdateVehicleTripEmployeeDto>
{
    public VehicleTripEmployeeController(IVehicleTripEmployeeService service) : base(service) { }


}

