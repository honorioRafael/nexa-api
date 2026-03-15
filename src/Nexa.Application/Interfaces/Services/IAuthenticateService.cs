using Nexa.Application.DTOs.Authenticate;

namespace Nexa.Application.Interfaces.Services;

public interface IAuthenticateService
{
    Task<AuthenticateDTO> Authenticate(InputAuthenticateDTO inputAuthenticateDTO);
}
