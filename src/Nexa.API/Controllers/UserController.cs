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
    private readonly ICurrentUser _currentUser;

    public UserController(IUserService userService, ICurrentUser currentUser) : base(userService)
    {
        _currentUser = currentUser;
    }

    [HttpPost]
    [AllowAnonymous]
    public override Task<IActionResult> Create(CreateUserDto dto, CancellationToken cancellationToken)
    {
        return base.Create(dto, cancellationToken);
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetMe(CancellationToken cancellationToken)
    {
        if (!_currentUser.Id.HasValue)
            return Unauthorized();

        var result = await _service.GetByIdAsync(_currentUser.Id.Value, cancellationToken);
        return result.Match(
            entity => Ok(MapToDto(entity)),
            HandleErrors);
    }

    [HttpPut("me")]
    public async Task<IActionResult> UpdateMe(UpdateUserDto dto, CancellationToken cancellationToken)
    {
        if (!_currentUser.Id.HasValue)
            return Unauthorized();

        var result = await _service.UpdateAsync(_currentUser.Id.Value, dto, cancellationToken);
        return result.Match(
            _ => NoContent(),
            HandleErrors);
    }

    [HttpPut("change-password")]
    public async Task<IActionResult> ChangePassword(ChangePasswordDto dto, CancellationToken cancellationToken)
    {
        if (!_currentUser.Id.HasValue)
            return Unauthorized();

        var result = await _service.ChangePasswordAsync(_currentUser.Id.Value, dto, cancellationToken);
        return result.Match(
            _ => NoContent(),
            HandleErrors);
    }
}
