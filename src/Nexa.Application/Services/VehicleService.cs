using ErrorOr;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class VehicleService : BaseService<Vehicle, IVehicleRepository, CreateVehicleDto, UpdateVehicleDto>, IVehicleService
{
    private readonly IVehicleModelRepository _vehicleModelRepository;

    public VehicleService(IVehicleRepository repository, IVehicleModelRepository vehicleModelRepository) : base(repository)
    {
        _vehicleModelRepository = vehicleModelRepository;
    }

    public override Task<List<Vehicle>> GetAllAsync(CancellationToken cancellationToken = default)
        => _repository.GetAllWithModelAsync(cancellationToken);

    public override async Task<ErrorOr<Success>> OnEntityCreating(CreateVehicleDto createDto, CancellationToken cancellationToken = default)
    {
        var model = await _vehicleModelRepository.GetByIdAsync(createDto.VehicleModelId, cancellationToken);
        if (model == null)
            return Error.NotFound(description: "Modelo de Veículo não encontrado.");

        var existingLicensePlate = await _repository.GetByLicensePlateAsync(createDto.LicensePlate, cancellationToken);
        if (existingLicensePlate != null)
            return Error.Conflict(description: "Já existe um veículo com esta Placa.");

        var existingChassis = await _repository.GetByChassisNumberAsync(createDto.ChassisNumber, cancellationToken);
        if (existingChassis != null)
            return Error.Conflict(description: "Já existe um veículo com este Número de Chassi.");

        return Result.Success;
    }

    public override async Task<ErrorOr<Success>> OnEntityUpdating(long id, UpdateVehicleDto updateDto, CancellationToken cancellationToken = default)
    {
        var existingLicensePlate = await _repository.GetByLicensePlateAsync(updateDto.LicensePlate, cancellationToken);
        if (existingLicensePlate != null && existingLicensePlate.Id != id)
            return Error.Conflict(description: "Já existe um veículo com esta Placa.");

        return Result.Success;
    }
}
