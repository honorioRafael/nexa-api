using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class DriverService : BaseService<Driver, IDriverRepository, CreateDriverDto, UpdateDriverDto>, IDriverService
{
    public DriverService(IDriverRepository repository) : base(repository)
    {
    }
}
