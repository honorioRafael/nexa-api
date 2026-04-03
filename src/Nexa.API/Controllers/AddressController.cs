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

    protected override AddressDto MapToDto(Address entity) =>
        new(entity.Id, entity.Name, entity.Street, entity.Number, entity.Complement, entity.Neighborhood, entity.City, entity.State, entity.Country, entity.ZipCode);
}
