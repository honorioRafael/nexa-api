using Nexa.Application.DTOs.Authenticate;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class AuthenticateService(IUserRepository userRepository, ITokenService tokenService) : IAuthenticateService
{
    public async Task<AuthenticateDTO> Authenticate(InputAuthenticateDTO inputAuthenticateDTO)
    {
        User? relatedUser = await userRepository.GetByEmail(inputAuthenticateDTO.Email);
        if (relatedUser == null)
            throw new Exception("Email inválido");

        if (!string.Equals(relatedUser.Password, inputAuthenticateDTO.Password, StringComparison.Ordinal))
            throw new Exception("Senha inválida");

        string token = tokenService.GenerateToken(relatedUser);

        return new AuthenticateDTO(token);
    }
}
