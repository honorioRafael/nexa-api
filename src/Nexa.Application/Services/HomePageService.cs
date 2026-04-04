using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class HomePageService(IEmployeeRepository employeeRepository, IVehicleRepository vehicleRepository, IHousingRepository housingRepository) : IHomePageService
{
    public async Task<HomePageDto> GetHomePageData(CancellationToken cancellationToken = default)
    {
        int totalEmployees = await employeeRepository.GetTotalActiveEmployeesAsync(cancellationToken);

        var (totalVehicles, availableVehicles) = await vehicleRepository.GetHomePageData(cancellationToken);
        int availabilityRate = totalVehicles == 0
            ? 0
            : (int)((double)availableVehicles / totalVehicles * 100);
        var vehicleDto = new HomePageVehiclesDto(totalVehicles, availableVehicles, availabilityRate);

        var (maxHousingCapacity, currentHousingCapacity) = await housingRepository.GetHomePageData(cancellationToken);
        int occupancyRate = maxHousingCapacity == 0
            ? 0
            : (int)((double)currentHousingCapacity / maxHousingCapacity * 100);
        var housingDTO = new HomePageHousingDto(currentHousingCapacity, maxHousingCapacity, occupancyRate);

        return new HomePageDto(totalEmployees, housingDTO, vehicleDto);
    }
}