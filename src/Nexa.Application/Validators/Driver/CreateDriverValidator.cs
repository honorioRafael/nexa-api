using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.Driver;

public class CreateDriverValidator : AbstractValidator<CreateDriverDto>
{
    public CreateDriverValidator()
    {
    }
}
