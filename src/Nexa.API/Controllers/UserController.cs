using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

public class UserController : BaseController<User, IUserService, UserDto, CreateUserDto, UpdateUserDto>
{
    public UserController(IUserService userService) : base(userService) { }


}

