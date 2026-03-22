using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class VehicleAllocationService : BaseService<VehicleAllocation, IVehicleAllocationRepository, CreateVehicleAllocationDto, UpdateVehicleAllocationDto>, IVehicleAllocationService
{
    public VehicleAllocationService(IVehicleAllocationRepository repository) : base(repository)
    {
    }
}
