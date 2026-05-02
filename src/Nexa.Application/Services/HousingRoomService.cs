using ErrorOr;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class HousingRoomService : BaseService<HousingRoom, IHousingRoomRepository, CreateHousingRoomDto, UpdateHousingRoomDto>, IHousingRoomService
{
    private readonly IHousingRepository _housingRepository;

    public HousingRoomService(IHousingRoomRepository repository, IHousingRepository housingRepository) : base(repository)
    {
        _housingRepository = housingRepository;
    }

    public override async Task<ErrorOr<Success>> OnEntityCreating(CreateHousingRoomDto createDto, CancellationToken cancellationToken = default)
    {
        var housing = await _housingRepository.GetByIdAsync(createDto.HousingId, cancellationToken);
        if (housing == null)
            return Error.NotFound(description: "Alojamento não encontrado.");

        return Result.Success;
    }
}
