using ErrorOr;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services.Base;
using Nexa.Domain.Entities;

namespace Nexa.Application.Interfaces.Services;

public interface IVehicleTripService : IBaseService<VehicleTrip, CreateVehicleTripDto, UpdateVehicleTripDto>
{
    Task<ErrorOr<VehicleTrip>> GetLastByVehicleIdAsync(long vehicleId, CancellationToken cancellationToken = default);
    Task<ErrorOr<List<VehicleTripDto>>> GetByHousingIdAsync(long housingId, CancellationToken cancellationToken = default);
}
