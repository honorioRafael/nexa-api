using Nexa.Domain.Entities;

namespace Nexa.Application.Interfaces.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}
