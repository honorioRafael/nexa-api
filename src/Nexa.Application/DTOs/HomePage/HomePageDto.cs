namespace Nexa.Application.DTOs;

public record HomePageDto(int ActiveEmployees, HomePageHousingDto HousingOccupation, HomePageVehiclesDto VehicleDisponibility);