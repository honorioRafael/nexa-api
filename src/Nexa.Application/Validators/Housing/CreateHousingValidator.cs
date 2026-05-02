using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.Housing;

public class CreateHousingValidator : AbstractValidator<CreateHousingDto>
{
    public CreateHousingValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");

        RuleFor(x => x.MaxCapacity)
            .GreaterThan(0).WithMessage("A capacidade máxima deve ser maior que 0.");

        RuleFor(x => x.HousingType)
            .NotEmpty().WithMessage("O tipo de alojamento é obrigatório.");

        RuleFor(x => x.UseHousingRoom)
            .NotNull().WithMessage("Obrigatório informar se utiliza quartos.");
    }
}
