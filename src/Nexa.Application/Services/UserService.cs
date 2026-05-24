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

        User? userByCpf = await _repository.GetByCpf(createDto.Cpf, cancellationToken);
        if (userByCpf != null)
            return Error.Conflict(description: "Já existe um usuário com esse CPF.");

        return Result.Success;
    }

    protected override void OnCreateEntityMapped(User entity, CreateUserDto createDto)
    {
        entity.Password = BCrypt.Net.BCrypt.HashPassword(entity.Password);
        entity.LastPasswordChange = DateTime.UtcNow;
    }
    #endregion

    #region Update
    public override async Task<ErrorOr<Success>> OnEntityUpdating(long id, UpdateUserDto updateDTO, CancellationToken cancellationToken = default)
    {
        User? userByCpf = await _repository.GetByCpf(updateDTO.Cpf, cancellationToken);
        if (userByCpf != null && userByCpf.Id != id)
            return Error.Conflict(description: "Já existe um usuário com esse CPF.");

        return Result.Success;
    }
    #endregion

    public async Task<ErrorOr<Success>> ChangePasswordAsync(long userId, ChangePasswordDto dto, CancellationToken cancellationToken = default)
    {
        User? user = await _repository.GetByIdAsync(userId, cancellationToken);
        if (user == null)
            return Error.NotFound(description: "Usuário não encontrado.");

        user.Password = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
        user.LastPasswordChange = DateTime.UtcNow;

        _repository.Update(user);
        await _repository.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}