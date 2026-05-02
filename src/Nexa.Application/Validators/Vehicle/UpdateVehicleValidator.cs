using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.Vehicle;

public class UpdateVehicleValidator : AbstractValidator<UpdateVehicleDto>
{
    public UpdateVehicleValidator()
    {
        RuleFor(x => x.Mileage)
            .GreaterThanOrEqualTo(0).WithMessage("A Quilometragem não pode ser negativa.");

        RuleFor(x => x.OriginCountry)
            .MaximumLength(50).WithMessage("O País de Origem deve ter no máximo 50 caracteres.");

        RuleFor(x => x.VehicleCondition)
            .IsInEnum().WithMessage("A Condição do Veículo informada é inválida.");
    }
}
