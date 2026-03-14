using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;
using Nexa.Infrastructure.Persistence;
using Nexa.Infrastructure.Repositories.Base;

namespace Nexa.Infrastructure.Repositories;

public class HousingRepository : BaseRepository<Housing>, IHousingRepository
{
    public HousingRepository(AppDbContext context) : base(context)
    {
    }
}
