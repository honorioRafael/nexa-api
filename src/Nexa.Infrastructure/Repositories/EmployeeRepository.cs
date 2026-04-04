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

    public async Task<int> GetTotalActiveEmployeesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.AsNoTracking().Where(x => x.Status == EmployeeStatus.Active).CountAsync(cancellationToken);
    }
}
