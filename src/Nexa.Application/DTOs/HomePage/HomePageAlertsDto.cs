namespace Nexa.Application.DTOs;

public record HomePageAlertsDto(int TotalActive, int CriticalCount, List<HomePageAlertDto> RecentAlerts);
