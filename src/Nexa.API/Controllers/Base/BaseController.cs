using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nexa.Application.Interfaces.Services.Base;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers.Base;

[ApiController]
[Authorize]
public abstract class BaseController<TEntity, TService, TResponseDto, TCreateDto, TUpdateDto> : ControllerBase
    where TEntity : Entity
    where TService : IBaseService<TEntity, TCreateDto, TUpdateDto>
{
    protected readonly TService _service;

    protected BaseController(TService service)
    {
        _service = service;
    }

    protected TResponseDto MapToDto(TEntity entity) => (TResponseDto)(dynamic)entity;

    protected IActionResult HandleErrors(List<Error> errors)
    {
        var first = errors[0];

        var statusCode = first.Type switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
            ErrorType.Forbidden => StatusCodes.Status403Forbidden,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(title: first.Code, detail: first.Description, statusCode: statusCode);
    }

    #region Get
    [HttpGet("{id}")]
    public virtual async Task<IActionResult> Get(long id, CancellationToken cancellationToken)
    {
        var result = await _service.GetByIdAsync(id, cancellationToken);
        return result.Match(
            entity => Ok(MapToDto(entity)),
            HandleErrors);
    }

    [HttpGet]
    public virtual async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _service.GetAllAsync(cancellationToken);
        return Ok(entities.Select(MapToDto));
    }
    #endregion

    #region Create
    [HttpPost]
    public virtual async Task<IActionResult> Create(TCreateDto dto, CancellationToken cancellationToken)
    {
        var result = await _service.CreateAsync(dto, cancellationToken);
        return result.Match(
            entity => CreatedAtAction(nameof(Get), new { id = entity.Id }, MapToDto(entity)),
            HandleErrors);
    }

    [HttpPost("bulk")]
    public virtual async Task<IActionResult> CreateMultiple(List<TCreateDto> dtos, CancellationToken cancellationToken)
    {
        var result = await _service.CreateMultipleAsync(dtos, cancellationToken);
        return result.Match(
            entities => Ok(entities.Select(MapToDto)),
            HandleErrors);
    }
    #endregion

    #region Update
    [HttpPut("{id}")]
    public virtual async Task<IActionResult> Update(long id, TUpdateDto dto, CancellationToken cancellationToken)
    {
        var result = await _service.UpdateAsync(id, dto, cancellationToken);
        return result.Match(
            _ => NoContent(),
            HandleErrors);
    }
    #endregion

    #region Delete
    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
    {
        var result = await _service.DeleteAsync(id, cancellationToken);
        return result.Match(
            _ => NoContent(),
            HandleErrors);
    }

    [HttpDelete("bulk")]
    public virtual async Task<IActionResult> DeleteMultiple(List<long> listid, CancellationToken cancellationToken)
    {
        var result = await _service.DeleteMultipleAsync(listid, cancellationToken);
        return result.Match(
            _ => NoContent(),
            HandleErrors);
    }
    #endregion
}