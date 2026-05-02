using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.VehicleModel;

public class CreateVehicleModelValidator : AbstractValidator<CreateVehicleModelDto>
{
    public CreateVehicleModelValidator()
    {
        RuleFor(x => x.Model)
            .NotEmpty().WithMessage("O Modelo é obrigatório.")
            .MaximumLength(100).WithMessage("O Modelo deve ter no máximo 100 caracteres.");

        RuleFor(x => x.Manufacturer)
            .NotEmpty().WithMessage("A Fabricante é obrigatória.")
            .MaximumLength(100).WithMessage("A Fabricante deve ter no máximo 100 caracteres.");

        RuleFor(x => x.Year)
            .InclusiveBetween(1900, DateTime.Now.Year + 1)
            .WithMessage($"O Ano deve estar entre 1900 e {DateTime.Now.Year + 1}.");

        RuleFor(x => x.FuelType)
            .NotEmpty().WithMessage("O Tipo de combustível é obrigatório.");

        RuleFor(x => x.MaxCapacity)
            .GreaterThan(0).WithMessage("A Capacidade máxima deve ser maior que 0.");
    }
}
