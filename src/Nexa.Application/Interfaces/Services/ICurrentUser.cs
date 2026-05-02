namespace Nexa.Application.Interfaces.Services;

public interface ICurrentUser
{
    long? Id { get; }
    bool IsAuthenticated { get; }
}