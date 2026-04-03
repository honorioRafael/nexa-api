using ErrorOr;
using Nexa.Application.Interfaces.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories.Base;
using System.Reflection;

namespace Nexa.Application.Services.Base;

public class BaseService<TEntity, TRepository, TCreateDto, TUpdateDto> : IBaseService<TEntity, TCreateDto, TUpdateDto>
    where TEntity : Entity, new()
    where TRepository : IBaseRepository<TEntity>
{
    protected readonly TRepository _repository;

    public BaseService(TRepository repository)
    {
        _repository = repository;
    }

    #region Get
    public virtual async Task<ErrorOr<TEntity>> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(id, cancellationToken);
        if (entity is null)
            return Error.NotFound(description: $"{typeof(TEntity).Name} com Id {id} não encontrado(a).");

        return entity;
    }

    public virtual async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }
    #endregion

    #region Create
    public virtual async Task<ErrorOr<TEntity>> CreateAsync(TCreateDto dto, CancellationToken cancellationToken = default)
    {
        var result = await CreateMultipleAsync([dto], cancellationToken);
        if (result.IsError) return result.Errors;
        return result.Value.First();
    }

    public virtual async Task<ErrorOr<List<TEntity>>> CreateMultipleAsync(List<TCreateDto> listDto, CancellationToken cancellationToken = default)
    {
        List<PropertyInfo> listEntityPropertyInfo = typeof(TEntity).GetProperties().ToList();
        var listDtoPropertyInfo = (from i in typeof(TCreateDto).GetProperties()
                                   let entityPropertyInfo = listEntityPropertyInfo.FirstOrDefault(x => x.Name == i.Name)
                                   where entityPropertyInfo is not null
                                   select new
                                   {
                                       DtoPropertyInfo = i,
                                       EntityPropertyInfo = entityPropertyInfo
                                   }).ToList();

        List<TEntity> listEntity = new();
        foreach (TCreateDto dto in listDto)
        {
            var onCreatingResult = await OnEntityCreating(dto, cancellationToken);
            if (onCreatingResult.IsError) return onCreatingResult.Errors;

            TEntity entity = new();
            foreach (var data in listDtoPropertyInfo)
            {
                data.EntityPropertyInfo.SetValue(entity, data.DtoPropertyInfo.GetValue(dto));
            }

            listEntity.Add(entity);
        }

        await _repository.CreateMultipleAsync(listEntity, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        return listEntity;
    }

    public virtual Task<ErrorOr<Success>> OnEntityCreating(TCreateDto createDto, CancellationToken cancellationToken = default)
        => Task.FromResult<ErrorOr<Success>>(Result.Success);
    #endregion

    #region Update
    public virtual async Task<ErrorOr<TEntity>> UpdateAsync(long id, TUpdateDto dto, CancellationToken cancellationToken = default)
    {
        List<PropertyInfo> listEntityPropertyInfo = typeof(TEntity).GetProperties().ToList();
        var listDtoPropertyInfo = (from i in typeof(TUpdateDto).GetProperties()
                                   let entityPropertyInfo = listEntityPropertyInfo.FirstOrDefault(x => x.Name == i.Name)
                                   where entityPropertyInfo is not null
                                   select new
                                   {
                                       DtoPropertyInfo = i,
                                       EntityPropertyInfo = entityPropertyInfo
                                   }).ToList();

        TEntity? entity = await _repository.GetByIdAsync(id, cancellationToken);
        if (entity is null)
            return Error.NotFound(description: $"{typeof(TEntity).Name} com Id {id} não encontrado(a).");

        var onUpdatingResult = await OnEntityUpdating(id, dto, cancellationToken);
        if (onUpdatingResult.IsError) return onUpdatingResult.Errors;

        foreach (var data in listDtoPropertyInfo)
        {
            data.EntityPropertyInfo.SetValue(entity, data.DtoPropertyInfo.GetValue(dto));
        }

        _repository.Update(entity);
        await _repository.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public virtual Task<ErrorOr<Success>> OnEntityUpdating(long id, TUpdateDto updateDTO, CancellationToken cancellationToken = default)
        => Task.FromResult<ErrorOr<Success>>(Result.Success);
    #endregion

    #region Delete
    public virtual async Task<ErrorOr<Deleted>> DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        var result = await DeleteMultipleAsync([id], cancellationToken);
        if (result.IsError) return result.Errors;
        return Result.Deleted;
    }

    public virtual async Task<ErrorOr<Deleted>> DeleteMultipleAsync(List<long> listId, CancellationToken cancellationToken = default)
    {
        List<TEntity> listEntity = await _repository.GetListByIdAsync(listId, cancellationToken);

        foreach (var id in listId)
        {
            if (!listEntity.Any(x => x.Id == id))
                return Error.NotFound(description: $"{typeof(TEntity).Name} com Id {id} não encontrado(a).");
        }

        _repository.DeleteMultiple(listEntity);
        await _repository.SaveChangesAsync(cancellationToken);

        return Result.Deleted;
    }
    #endregion
}
