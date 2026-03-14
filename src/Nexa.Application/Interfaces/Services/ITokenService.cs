using System.Security.Claims;

namespace Nexa.Application.Interfaces.Services;

public interface ITokenService
{
    string GenerateToken(IEnumerable<Claim> claims);
}
