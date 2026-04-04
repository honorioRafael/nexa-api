using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

public class DriverController : BaseController<Driver, IDriverService, DriverDto, CreateDriverDto, UpdateDriverDto>
{
    public DriverController(IDriverService driverService) : base(driverService) { }


}

