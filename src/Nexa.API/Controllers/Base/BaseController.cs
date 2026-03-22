using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nexa.Application.Interfaces.Services.Base;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers.Base;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public abstract class BaseController<TEntity, TService, TCreateDto, TUpdateDto> : ControllerBase
    where TEntity : Entity
    where TService : IBaseService<TEntity, TCreateDto, TUpdateDto>
{
    protected readonly TService _service;

    protected BaseController(TService service)
    {
        _service = service;
    }

    #region Get
    [HttpGet("Get/{id}")]
    public abstract Task<IActionResult> Get(long id);

    [HttpGet("GetAll")]
    public abstract Task<IActionResult> GetAll();
    #endregion

    #region Create
    [HttpPost("Create")]
    public abstract Task<IActionResult> Create(TCreateDto dto);

    [HttpPost("CreateMultiple")]
    public abstract Task<IActionResult> CreateMultiple(List<TCreateDto> dtos);
    #endregion

    #region Update
    [HttpPut("Update/{id}")]
    public abstract Task<IActionResult> Update(long id, TUpdateDto dto);

    [HttpPut("UpdateMultiple")]
    public abstract Task<IActionResult> UpdateMultiple(Dictionary<long, TUpdateDto> idDtoPairs);
    #endregion

    #region Delete
    [HttpDelete("Delete/{id}")]
    public abstract Task<IActionResult> Delete(long id);

    [HttpDelete("DeleteMultiple")]
    public abstract Task<IActionResult> DeleteMultiple(List<long> listid);
    #endregion
}