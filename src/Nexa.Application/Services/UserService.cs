using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services.Base;
using Nexa.Domain.Entities;
using Nexa.Domain.Interfaces.Repositories;

namespace Nexa.Application.Services;

public class UserService : BaseService<User, IUserRepository, CreateUserDto, UpdateUserDto>, IUserService
{
    public UserService(IUserRepository repository) : base(repository)
    {
    }
}
