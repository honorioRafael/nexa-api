using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services.Base;
using Nexa.Domain.Entities;

using ErrorOr;

namespace Nexa.Application.Interfaces.Services;

public interface IUserService : IBaseService<User, CreateUserDto, UpdateUserDto>
{
    Task<ErrorOr<Success>> ChangePasswordAsync(long userId, ChangePasswordDto dto, CancellationToken cancellationToken = default);
}
