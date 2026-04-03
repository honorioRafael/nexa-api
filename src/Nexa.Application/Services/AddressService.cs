using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class AddressService : BaseService<Address, IAddressRepository, CreateAddressDto, UpdateAddressDto>, IAddressService
{
    public AddressService(IAddressRepository repository) : base(repository) { }
}
