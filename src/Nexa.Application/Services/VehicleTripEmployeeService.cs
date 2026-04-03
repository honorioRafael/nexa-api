using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class VehicleTripEmployeeService : BaseService<VehicleTripEmployee, IVehicleTripEmployeeRepository, CreateVehicleTripEmployeeDto, UpdateVehicleTripEmployeeDto>, IVehicleTripEmployeeService
{
    public VehicleTripEmployeeService(IVehicleTripEmployeeRepository repository) : base(repository) { }
}
