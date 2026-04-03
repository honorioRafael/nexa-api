using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.VehicleTripStop;

public class CreateVehicleTripStopValidator : AbstractValidator<CreateVehicleTripStopDto>
{
    public CreateVehicleTripStopValidator()
    {
    }
}
