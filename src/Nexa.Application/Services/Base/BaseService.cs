using Nexa.Application.Interfaces.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories.Base;

namespace Nexa.Application.Services.Base;

public class BaseService<TEntity, TRepository> : IBaseService<TEntity>
    where TEntity : Entity
    where TRepository : IBaseRepository<TEntity>
{
    protected readonly TRepository _repository;

    public BaseService(TRepository repository)
    {
        _repository = repository;
    }

    public virtual async Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return await _repository.GetByIdAsync(id, cancellationToken);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }

    public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _repository.AddAsync(entity, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _repository.Update(entity);
        await _repository.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(id, cancellationToken);
        if (entity != null)
        {
            _repository.Delete(entity);
            await _repository.SaveChangesAsync(cancellationToken);
        }
    }
}
