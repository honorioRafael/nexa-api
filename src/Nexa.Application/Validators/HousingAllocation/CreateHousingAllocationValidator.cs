using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.HousingAllocation;

public class CreateHousingAllocationValidator : AbstractValidator<CreateHousingAllocationDto>
{
    public CreateHousingAllocationValidator()
    {
        RuleFor(x => x.CheckInDate)
            .NotEmpty().WithMessage("A data de check-in é obrigatória.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("A data de check-in não pode ser uma data futura.");

        RuleFor(x => x.CheckOutDate)
            .GreaterThanOrEqualTo(x => x.CheckInDate).WithMessage("A data de check-out deve ser maior ou igual à data de check-in.")
            .When(x => x.CheckOutDate.HasValue);
    }
}
