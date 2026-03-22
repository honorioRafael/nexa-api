using Nexa.Domain.Entities;

namespace Nexa.Application.Interfaces.Services.Base;

public interface IBaseService<TEntity, TCreateDto, TUpdateDto> where TEntity : Entity
{
    #region Get
    Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    #endregion

    #region Create
    Task<TEntity> CreateAsync(TCreateDto dto, CancellationToken cancellationToken = default);
    Task<List<TEntity>> CreateMultipleAsync(List<TCreateDto> dtos, CancellationToken cancellationToken = default);
    #endregion

    #region Update
    Task<TEntity> UpdateAsync(long id, TUpdateDto dto, CancellationToken cancellationToken = default);
    Task<List<TEntity>> UpdateMultipleAsync(Dictionary<long, TUpdateDto> idDtoPairs, CancellationToken cancellationToken = default);
    #endregion

    #region Delete
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
    Task DeleteMultipleAsync(List<long> listid, CancellationToken cancellationToken = default);
    #endregion
}
