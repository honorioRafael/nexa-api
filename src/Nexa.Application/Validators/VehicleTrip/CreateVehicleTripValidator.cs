using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.VehicleTrip;

public class CreateVehicleTripValidator : AbstractValidator<CreateVehicleTripDto>
{
    public CreateVehicleTripValidator()
    {
        RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("A Data de Início é obrigatória.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("A Descrição é obrigatória.");
    }
}
