using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class HomePageService(IEmployeeRepository employeeRepository, IVehicleRepository vehicleRepository, IHousingRepository housingRepository) : IHomePageService
{
    public async Task<HomePageDto> GetHomePageData(CancellationToken cancellationToken = default)
    {
        var (totalEmployees, activeEmployees) = await employeeRepository.GetHomePageData(cancellationToken);
        int activeRate = totalEmployees == 0
            ? 0
            : (int)((double)activeEmployees / totalEmployees * 100);
        var employeesDto = new HomePageEmployeesDto(totalEmployees, activeEmployees, activeRate);

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

        return new HomePageDto(employeesDto, housingDTO, vehicleDto);
    }
}