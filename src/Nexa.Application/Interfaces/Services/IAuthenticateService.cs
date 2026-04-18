using ErrorOr;
using Nexa.Application.DTOs.Authenticate;

namespace Nexa.Application.Interfaces.Services;

public interface IAuthenticateService
{
    Task<ErrorOr<AuthenticateDto>> Authenticate(InputAuthenticateDto inputAuthenticateDTO);
}
