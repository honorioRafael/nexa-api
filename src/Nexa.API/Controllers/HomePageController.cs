using Microsoft.AspNetCore.Mvc;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;

namespace Nexa.API.Controllers;

[ApiController]
[Route("api/home")]
public class HomePageController(IHomePageService service) : ControllerBase
{
    [HttpGet]
    public async Task<HomePageDto> GetHomePageData(CancellationToken cancellationToken)
    {
        return await service.GetHomePageData(cancellationToken);
    }
}