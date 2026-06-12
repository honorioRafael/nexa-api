namespace Nexa.Application.DTOs;

public record HomePageVehiclesDto(int Total, int Available, int InUse, int Maintenance, int AvailabilityRate);