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
    public virtual async Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return await _repository.GetByIdAsync(id, cancellationToken);
    }

    public virtual async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }
    #endregion

    #region Create
    public virtual async Task<TEntity> CreateAsync(TCreateDto dto, CancellationToken cancellationToken = default)
    {
        var result = await CreateMultipleAsync([dto], cancellationToken);
        return result.First();
    }

    public virtual async Task<List<TEntity>> CreateMultipleAsync(List<TCreateDto> listDto, CancellationToken cancellationToken = default)
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

        List<TEntity> listEntity = new List<TEntity>();
        foreach (TCreateDto dto in listDto)
        {
            TEntity entity = new TEntity();

            await OnEntityCreating(dto, cancellationToken);

            foreach (var data in listDtoPropertyInfo)
            {
                data.EntityPropertyInfo.SetValue(entity, data.DtoPropertyInfo.GetValue(dto));
            }

            listEntity.Add(entity);
        }

        await _repository.CreateMultipleAsync(listEntity, cancellationToken);
        await _repository.SaveChangesAsync();

        return listEntity;
    }

    public virtual async Task OnEntityCreating(TCreateDto createDto, CancellationToken cancellationToken = default) { }
    #endregion

    #region Update
    public virtual async Task<TEntity> UpdateAsync(long id, TUpdateDto dto, CancellationToken cancellationToken = default)
    {
        var result = await UpdateMultipleAsync(new Dictionary<long, TUpdateDto> { { id, dto } }, cancellationToken);
        return result.First();
    }

    public virtual async Task<List<TEntity>> UpdateMultipleAsync(Dictionary<long, TUpdateDto> listDTO, CancellationToken cancellationToken = default)
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

        List<TEntity> listRelatedEntity = await _repository.GetListByIdAsync(listDTO.Keys.ToList(), cancellationToken);

        foreach (var dto in listDTO)
        {
            TEntity entity = listRelatedEntity.FirstOrDefault(x => x.Id == dto.Key) ?? throw new KeyNotFoundException($"{nameof(TEntity)} com Id {dto.Key} não encontrado(a).");

            await OnEntityUpdating(dto.Key, dto.Value, cancellationToken);

            foreach (var data in listDtoPropertyInfo)
            {
                data.EntityPropertyInfo.SetValue(entity, data.DtoPropertyInfo.GetValue(dto.Value));
            }
        }

        _repository.UpdateMultiple(listRelatedEntity);
        await _repository.SaveChangesAsync();

        return listRelatedEntity;
    }

    public virtual async Task OnEntityUpdating(long id, TUpdateDto updateDTO, CancellationToken cancellationToken = default) { }
    #endregion

    #region Delete
    public virtual async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        await DeleteMultipleAsync([id], cancellationToken);
    }

    public virtual async Task DeleteMultipleAsync(List<long> listId, CancellationToken cancellationToken = default)
    {
        List<TEntity> listEntity = await _repository.GetListByIdAsync(listId, cancellationToken);

        foreach (var id in listId)
        {
            if (!listEntity.Any(x => x.Id == id))
                throw new KeyNotFoundException($"{typeof(TEntity).Name} com Id {id} não encontrado(a).");
        }

        _repository.DeleteMultiple(listEntity);
        await _repository.SaveChangesAsync(cancellationToken);
    }
    #endregion
}
