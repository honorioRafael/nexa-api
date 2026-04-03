using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.Driver;

public class UpdateDriverValidator : AbstractValidator<UpdateDriverDto>
{
    public UpdateDriverValidator()
    {
    }
}
