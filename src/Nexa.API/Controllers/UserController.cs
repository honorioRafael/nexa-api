using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nexa.API.Controllers.Base;
using Nexa.Application.DTOs;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Entities;

namespace Nexa.API.Controllers;

[Route("api/users")]
public class UserController : BaseController<User, IUserService, UserDto, CreateUserDto, UpdateUserDto>
{
    public UserController(IUserService userService) : base(userService) { }

    [HttpPost]
    [AllowAnonymous]
    public override Task<IActionResult> Create(CreateUserDto dto, CancellationToken cancellationToken)
    {
        return base.Create(dto, cancellationToken);
    }
}

