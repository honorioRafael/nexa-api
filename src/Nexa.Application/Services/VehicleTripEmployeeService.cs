using ErrorOr;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class VehicleTripEmployeeService : BaseService<VehicleTripEmployee, IVehicleTripEmployeeRepository, CreateVehicleTripEmployeeDto, UpdateVehicleTripEmployeeDto>, IVehicleTripEmployeeService
{
    private readonly IVehicleTripRepository _vehicleTripRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public VehicleTripEmployeeService(
        IVehicleTripEmployeeRepository repository,
        IVehicleTripRepository vehicleTripRepository,
        IEmployeeRepository employeeRepository) : base(repository)
    {
        _vehicleTripRepository = vehicleTripRepository;
        _employeeRepository = employeeRepository;
    }

    public override async Task<ErrorOr<Success>> OnEntityCreating(CreateVehicleTripEmployeeDto createDto, CancellationToken cancellationToken = default)
    {
        var vehicleTrip = await _vehicleTripRepository.GetByIdAsync(createDto.VehicleTripId, cancellationToken);
        if (vehicleTrip == null)
            return Error.NotFound(description: "VehicleTrip não encontrado.");

        var employee = await _employeeRepository.GetByIdAsync(createDto.EmployeeId, cancellationToken);
        if (employee == null)
            return Error.NotFound(description: "Employee não encontrado.");

        return Result.Success;
    }
}
