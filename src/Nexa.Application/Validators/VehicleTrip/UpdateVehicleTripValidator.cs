using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.VehicleTrip;

public class UpdateVehicleTripValidator : AbstractValidator<UpdateVehicleTripDto>
{
    public UpdateVehicleTripValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("A Descrição é obrigatória.");
    }
}
