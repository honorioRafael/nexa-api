using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class HomePageService(
    IEmployeeRepository employeeRepository,
    IVehicleRepository vehicleRepository,
    IHousingRepository housingRepository,
    IVehicleMaintenanceRepository vehicleMaintenanceRepository,
    IHousingAllocationRepository housingAllocationRepository) : IHomePageService
{
    public async Task<HomePageDto> GetHomePageData(CancellationToken cancellationToken = default)
    {
        var now = DateTime.Now.ToString("HH:mm");

        // Employees
        var (totalEmployees, activeEmployees) = await employeeRepository.GetHomePageData(cancellationToken);
        int activeRate = totalEmployees == 0
            ? 0
            : (int)((double)activeEmployees / totalEmployees * 100);
        var employeesDto = new HomePageEmployeesDto(totalEmployees, activeEmployees, activeRate);

        // Vehicles
        var (totalVehicles, availableVehicles) = await vehicleRepository.GetHomePageData(cancellationToken);
        int availabilityRate = totalVehicles == 0
            ? 0
            : (int)((double)availableVehicles / totalVehicles * 100);
        var vehicleDto = new HomePageVehiclesDto(totalVehicles, availableVehicles, availabilityRate);

        // Housing — capacidade máxima do repositório; ocupação atual calculada via alocações
        var maxHousingCapacity = await housingRepository.GetMaxCapacityAsync(cancellationToken);
        var currentHousingCapacity = await housingAllocationRepository.GetTotalCurrentOccupancyAsync(cancellationToken);
        int occupancyRate = maxHousingCapacity == 0
            ? 0
            : (int)((double)currentHousingCapacity / maxHousingCapacity * 100);
        var housingDTO = new HomePageHousingDto(currentHousingCapacity, maxHousingCapacity, occupancyRate);

        // Alerts
        var fullHousingsCount = await housingAllocationRepository.GetFullHousingsCount(cancellationToken);
        var openMaintenancesCount = await vehicleMaintenanceRepository.GetOpenMaintenancesCount(cancellationToken);
        var pendingCheckOutCount = await housingAllocationRepository.GetPendingCheckOutCount(cancellationToken);

        var alerts = new List<HomePageAlertDto>();

        if (fullHousingsCount > 0)
            alerts.Add(new HomePageAlertDto(
                $"{fullHousingsCount} alojamento(s) com capacidade máxima",
                $"{currentHousingCapacity} / {maxHousingCapacity} ocupados",
                now,
                AlertSeverity.Critical));

        if (openMaintenancesCount > 0)
            alerts.Add(new HomePageAlertDto(
                $"{openMaintenancesCount} veículo(s) precisam de manutenção",
                "Verifique a programação",
                now,
                AlertSeverity.Warning));

        if (pendingCheckOutCount > 0)
            alerts.Add(new HomePageAlertDto(
                $"Check-out pendente de {pendingCheckOutCount} trabalhador(es)",
                "Ações necessárias",
                now,
                AlertSeverity.Warning));

        int criticalCount = alerts.Count(a => a.Severity == AlertSeverity.Critical);
        var alertsDto = new HomePageAlertsDto(alerts.Count, criticalCount, alerts);

        return new HomePageDto(employeesDto, housingDTO, vehicleDto, alertsDto);
    }
}