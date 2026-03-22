using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class HousingService : BaseService<Housing, IHousingRepository, CreateHousingDto, UpdateHousingDto>, IHousingService
{
    public HousingService(IHousingRepository repository) : base(repository)
    {
    }
}
