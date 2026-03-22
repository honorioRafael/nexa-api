using Nexa.Domain.Entities;

namespace Nexa.Domain.Interfaces.Repositories.Base;

public interface IBaseRepository<TEntity> where TEntity : Entity
{
    #region Get
    Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<List<TEntity>> GetListByIdAsync(List<long> listId, CancellationToken cancellationToken = default);
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    #endregion

    #region Create
    Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task CreateMultipleAsync(List<TEntity> entities, CancellationToken cancellationToken = default);
    #endregion

    #region Update
    void Update(TEntity entity);
    void UpdateMultiple(List<TEntity> entities);
    #endregion

    #region Delete
    void Delete(TEntity entity);
    void DeleteMultiple(List<TEntity> entities);
    #endregion

    #region SaveChanges
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    #endregion
}
