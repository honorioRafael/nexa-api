using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : BaseController<User, IUserService, UserDto, CreateUserDto, UpdateUserDto>
{
    public UserController(IUserService userService) : base(userService) { }

    protected override UserDto MapToDto(User entity) =>
        new(entity.Id, entity.Email);
}
