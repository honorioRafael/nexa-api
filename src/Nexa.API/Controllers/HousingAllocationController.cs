using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

public class HousingAllocationController : BaseController<HousingAllocation, IHousingAllocationService, HousingAllocationDto, CreateHousingAllocationDto, UpdateHousingAllocationDto>
{
    public HousingAllocationController(IHousingAllocationService housingAllocationService) : base(housingAllocationService) { }


}

