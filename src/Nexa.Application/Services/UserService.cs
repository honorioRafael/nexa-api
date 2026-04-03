using ErrorOr;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class UserService : BaseService<User, IUserRepository, CreateUserDto, UpdateUserDto>, IUserService
{
    public UserService(IUserRepository repository) : base(repository) { }

    #region Create
    public override async Task<ErrorOr<Success>> OnEntityCreating(CreateUserDto createDto, CancellationToken cancellationToken = default)
    {
        User? userByEmail = await _repository.GetByEmail(createDto.Email, cancellationToken);
        if (userByEmail != null)
            return Error.Conflict(description: "Já existe um usuário com esse email.");

        return Result.Success;
    }
    #endregion

    #region Update
    public override async Task<ErrorOr<Success>> OnEntityUpdating(long id, UpdateUserDto updateDTO, CancellationToken cancellationToken = default)
    {
        User? userByEmail = await _repository.GetByEmail(updateDTO.Email, cancellationToken);
        if (userByEmail != null && userByEmail.Id != id)
            return Error.Conflict(description: "Já existe um usuário com esse email.");

        return Result.Success;
    }
    #endregion
}