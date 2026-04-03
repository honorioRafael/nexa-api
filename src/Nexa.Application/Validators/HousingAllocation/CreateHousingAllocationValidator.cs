using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.HousingAllocation;

public class CreateHousingAllocationValidator : AbstractValidator<CreateHousingAllocationDto>
{
    public CreateHousingAllocationValidator()
    {
    }
}
