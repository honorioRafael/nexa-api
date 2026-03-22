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
    public override async Task OnEntityCreating(CreateUserDto createDto, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(createDto.Email))
            throw new Exception("O email é obrigatório");

        if (createDto.Email.Length > 255)
            throw new Exception("O email deve ter no máximo 255 caracteres");

        if (!createDto.Email.Contains('@'))
            throw new Exception("O email não é válido");

        User? userByEmail = await _repository.GetByEmail(createDto.Email, cancellationToken);
        if(userByEmail != null)
            throw new Exception("Já existe um usuário com esse email");

        if(createDto.Password.Length < 8)
            throw new Exception("A senha deve ter no mínimo 8 caracteres");
    }
    #endregion

    #region Update
    public override async Task OnEntityUpdating(long id, UpdateUserDto updateDTO, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(updateDTO.Email))
            throw new Exception("O email é obrigatório");

        if (updateDTO.Email.Length > 255)
            throw new Exception("O email deve ter no máximo 255 caracteres");

        if (!updateDTO.Email.Contains('@'))
            throw new Exception("O email não é válido");

        User? userByEmail = await _repository.GetByEmail(updateDTO.Email, cancellationToken);
        if (userByEmail != null)
            throw new Exception("Já existe um usuário com esse email");

        if (updateDTO.Password.Length < 8)
            throw new Exception("A senha deve ter no mínimo 8 caracteres");
    }
    #endregion
}