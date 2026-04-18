using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nexa.Application.Interfaces.Services.Base;
using Nexa.Domain.Entities;
using System.Linq.Expressions;
using System.Reflection;

namespace Nexa.API.Controllers.Base;

[Authorize]
public abstract class BaseController<TEntity, TService, TResponseDto, TCreateDto, TUpdateDto> : ApiController
    where TEntity : Entity
    where TService : IBaseService<TEntity, TCreateDto, TUpdateDto>
{
    protected readonly TService _service;

    private static readonly Func<TEntity, TResponseDto> _mapToDto = CompileMapper();

    private static Func<TEntity, TResponseDto> CompileMapper()
    {
        var implicitOp = typeof(TResponseDto)
            .GetMethods(BindingFlags.Static | BindingFlags.Public)
            .FirstOrDefault(m =>
                m.Name == "op_Implicit" &&
                m.GetParameters().Length == 1 &&
                m.GetParameters()[0].ParameterType.IsAssignableFrom(typeof(TEntity)));

        if (implicitOp is null)
            throw new InvalidOperationException(
                $"O DTO '{typeof(TResponseDto).Name}' deve definir um implicit operator recebendo '{typeof(TEntity).Name}'.");

        var param = Expression.Parameter(typeof(TEntity), "entity");
        var body = Expression.Convert(Expression.Call(implicitOp, param), typeof(TResponseDto));
        return Expression.Lambda<Func<TEntity, TResponseDto>>(body, param).Compile();
    }

    protected BaseController(TService service)
    {
        _service = service;
    }

    protected TResponseDto MapToDto(TEntity entity) => _mapToDto(entity);

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