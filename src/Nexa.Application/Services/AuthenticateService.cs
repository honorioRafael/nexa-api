using ErrorOr;
using Nexa.Application.DTOs.Authenticate;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class AuthenticateService(IUserRepository userRepository, ITokenService tokenService) : IAuthenticateService
{
    public async Task<ErrorOr<AuthenticateDto>> Authenticate(InputAuthenticateDto inputAuthenticateDTO)
    {
        var relatedUser = await userRepository.GetByEmail(inputAuthenticateDTO.Email);

        if (relatedUser is null || !BCrypt.Net.BCrypt.Verify(inputAuthenticateDTO.Password, relatedUser.Password))
            return Error.Unauthorized(description: "Credenciais inválidas.");

        string token = tokenService.GenerateToken(relatedUser);

        return new AuthenticateDto(token);
    }
}
