using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HousingRoomController : BaseController<HousingRoom, IHousingRoomService, HousingRoomDto, CreateHousingRoomDto, UpdateHousingRoomDto>
{
    public HousingRoomController(IHousingRoomService service) : base(service) { }


}
