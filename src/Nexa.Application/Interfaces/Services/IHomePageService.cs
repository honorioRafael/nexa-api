using Nexa.Application.DTOs;

namespace Nexa.Application.Interfaces.Services;

public interface IHomePageService
{
    Task<HomePageDto> GetHomePageData(CancellationToken cancellationToken = default);
}