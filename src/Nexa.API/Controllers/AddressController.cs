using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController : BaseController<Address, IAddressService, AddressDto, CreateAddressDto, UpdateAddressDto>
{
    public AddressController(IAddressService service) : base(service) { }


}
