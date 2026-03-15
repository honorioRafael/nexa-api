using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nexa.Application.Interfaces.Services.Base;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers.Base;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public abstract class BaseController<TEntity, TService> : ControllerBase
    where TEntity : Entity
    where TService : IBaseService<TEntity>
{
    protected readonly TService _service;

    protected BaseController(TService service)
    {
        _service = service;
    }
}
