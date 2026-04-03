using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.Housing;

public class CreateHousingValidator : AbstractValidator<CreateHousingDto>
{
    public CreateHousingValidator()
    {
    }
}
