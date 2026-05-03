using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories.Base;

namespace Nexa.Domain.Interfaces.Repositories;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    Task<(int TotalEmployees, int ActiveEmployees)> GetHomePageData(CancellationToken cancellationToken = default);
    Task<Employee?> GetByCpfAsync(string cpf, CancellationToken cancellationToken = default);
}