using ErrorOr;
using Nexa.Domain.Entities;

namespace Nexa.Application.Interfaces.Services.Base;

public interface IBaseService<TEntity, TCreateDto, TUpdateDto> where TEntity : Entity
{
    #region Get
    Task<ErrorOr<TEntity>> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    #endregion

    #region Create
    Task<ErrorOr<TEntity>> CreateAsync(TCreateDto dto, CancellationToken cancellationToken = default);
    Task<ErrorOr<List<TEntity>>> CreateMultipleAsync(List<TCreateDto> dtos, CancellationToken cancellationToken = default);
    #endregion

    #region Update
    Task<ErrorOr<TEntity>> UpdateAsync(long id, TUpdateDto dto, CancellationToken cancellationToken = default);
    #endregion

    #region Delete
    Task<ErrorOr<Deleted>> DeleteAsync(long id, CancellationToken cancellationToken = default);
    Task<ErrorOr<Deleted>> DeleteMultipleAsync(List<long> listid, CancellationToken cancellationToken = default);
    #endregion
}
