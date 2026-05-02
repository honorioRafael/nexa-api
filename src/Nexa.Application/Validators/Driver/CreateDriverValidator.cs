using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.Driver;

public class CreateDriverValidator : AbstractValidator<CreateDriverDto>
{
    public CreateDriverValidator()
    {
        RuleFor(x => x.LicenseNumber)
            .NotEmpty().WithMessage("O número da CNH é obrigatório.");

        RuleFor(x => x.LicenseExpiration)
            .NotEmpty().WithMessage("A data de validade da CNH é obrigatória.")
            .GreaterThan(DateTime.UtcNow).WithMessage("A validade da CNH deve ser uma data futura.");

        RuleFor(x => x.LicenseType)
            .NotEmpty().WithMessage("A categoria da CNH é obrigatória.")
            .Must(x => new[] { "A", "B", "C", "D", "E" }.Contains(x?.ToUpper()))
            .WithMessage("A categoria da CNH deve ser A, B, C, D ou E.");
    }
}
