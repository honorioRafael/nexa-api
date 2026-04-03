using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.HousingAllocation;

public class UpdateHousingAllocationValidator : AbstractValidator<UpdateHousingAllocationDto>
{
    public UpdateHousingAllocationValidator()
    {
    }
}
