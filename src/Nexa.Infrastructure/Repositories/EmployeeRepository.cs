using Microsoft.EntityFrameworkCore;
using Nexa.Domain.Entities;
using Nexa.Domain.Enums;
using Nexa.Domain.Interfaces.Repositories;
using Nexa.Infrastructure.Persistence;
using Nexa.Infrastructure.Repositories.Base;

namespace Nexa.Infrastructure.Repositories;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(AppDbContext context) : base(context) { }

    public async Task<(int TotalEmployees, int ActiveEmployees)> GetHomePageData(CancellationToken cancellationToken = default)
    {
        var totalEmployees = await _dbSet.AsNoTracking().CountAsync(cancellationToken);
        var activeEmployees = await _dbSet.AsNoTracking().CountAsync(x => x.Status == EmployeeStatus.Active, cancellationToken);
        
        return (totalEmployees, activeEmployees);
    }

    public Task<Employee?> GetByCpfAsync(string cpf, CancellationToken cancellationToken = default)
    {
        return _dbSet.FirstOrDefaultAsync(x => x.Cpf == cpf, cancellationToken);
    }
}
