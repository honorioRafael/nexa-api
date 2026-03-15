namespace Nexa.Application.DTOs.Authenticate;

public class AuthenticateDTO
{
    public string Token { get; private set; }

    public AuthenticateDTO(string token)
    {
        Token = token;
    }
}
