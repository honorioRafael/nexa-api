using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.VehicleTripStop;

public class UpdateVehicleTripStopValidator : AbstractValidator<UpdateVehicleTripStopDto>
{
    public UpdateVehicleTripStopValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("A Descrição é obrigatória.");

        RuleFor(x => x.QueuePosition)
            .GreaterThanOrEqualTo(0).WithMessage("A Posição na Fila deve ser maior ou igual a 0.");
    }
}
