using ErrorOr;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class HousingService : BaseService<Housing, IHousingRepository, CreateHousingDto, UpdateHousingDto>, IHousingService
{
    private readonly IAddressRepository _addressRepository;

    public HousingService(IHousingRepository repository, IAddressRepository addressRepository) : base(repository)
    {
        _addressRepository = addressRepository;
    }

    public override async Task<ErrorOr<Success>> OnEntityCreating(CreateHousingDto createDto, CancellationToken cancellationToken = default)
    {
        var address = await _addressRepository.GetByIdAsync(createDto.AddressId, cancellationToken);
        if (address == null)
            return Error.NotFound(description: "Address não encontrado.");

        return Result.Success;
    }

    public override async Task<ErrorOr<Success>> OnEntityUpdating(long id, UpdateHousingDto updateDto, CancellationToken cancellationToken = default)
    {
        var address = await _addressRepository.GetByIdAsync(updateDto.AddressId, cancellationToken);
        if (address == null)
            return Error.NotFound(description: "Address não encontrado.");

        return Result.Success;
    }
}
