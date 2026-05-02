using ErrorOr;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class DriverService : BaseService<Driver, IDriverRepository, CreateDriverDto, UpdateDriverDto>, IDriverService
{
    private readonly ICurrentUser _currentUser;

    public DriverService(IDriverRepository repository, ICurrentUser currentUser) : base(repository)
    {
        _currentUser = currentUser;
    }

    protected override void OnCreateEntityMapped(Driver entity, CreateDriverDto createDto)
    {
        entity.UserId = _currentUser.Id!.Value;
    }
}
