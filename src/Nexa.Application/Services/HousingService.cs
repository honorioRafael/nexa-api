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
    private readonly IHousingAllocationRepository _housingAllocationRepository;

    public HousingService(
        IHousingRepository repository,
        IAddressRepository addressRepository,
        IHousingAllocationRepository housingAllocationRepository) : base(repository)
    {
        _addressRepository = addressRepository;
        _housingAllocationRepository = housingAllocationRepository;
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

    public async Task<HousingDto?> GetByIdWithOccupancyAsync(long id, CancellationToken cancellationToken = default)
    {
        var housing = await _repository.GetByIdAsync(id, cancellationToken);
        if (housing is null) return null;

        var currentOccupancy = await _housingAllocationRepository.GetCurrentOccupancyByHousingIdAsync(housing.Id, cancellationToken);
        HousingDto dto = new(housing.Id, housing.Name, housing.AddressId, housing.MaxCapacity, currentOccupancy, housing.HousingStatus, housing.HousingType, housing.UseHousingRoom, housing.Address);
        return dto;
    }

    public async Task<List<HousingDto>> GetAllWithOccupancyAsync(CancellationToken cancellationToken = default)
    {
        var housings = await _repository.GetAllAsync(cancellationToken);
        var result = new List<HousingDto>(housings.Count);

        foreach (var housing in housings)
        {
            var currentOccupancy = await _housingAllocationRepository.GetCurrentOccupancyByHousingIdAsync(housing.Id, cancellationToken);
            HousingDto dto = new(housing.Id, housing.Name, housing.AddressId, housing.MaxCapacity, currentOccupancy, housing.HousingStatus, housing.HousingType, housing.UseHousingRoom, housing.Address);
            result.Add(dto);
        }

        return result;
    }
}
