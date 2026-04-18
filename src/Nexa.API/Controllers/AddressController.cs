using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

[Route("api/addresses")]
public class AddressController : BaseController<Address, IAddressService, AddressDto, CreateAddressDto, UpdateAddressDto>
{
    public AddressController(IAddressService service) : base(service) { }


}

