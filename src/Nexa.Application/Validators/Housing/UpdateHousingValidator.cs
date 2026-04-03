using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.Housing;

public class UpdateHousingValidator : AbstractValidator<UpdateHousingDto>
{
    public UpdateHousingValidator()
    {
    }
}
