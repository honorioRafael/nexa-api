namespace Nexa.Application.DTOs;

public record HomePageDto(HomePageEmployeesDto Employees, HomePageHousingDto HousingOccupation, HomePageVehiclesDto VehicleDisponibility, HomePageAlertsDto Alerts);