namespace Nexa.Application.DTOs.Authenticate;

public class AuthenticateDto
{
    public string Token { get; private set; }

    public AuthenticateDto(string token)
    {
        Token = token;
    }
}
