using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.VehicleTrip;

public class CreateVehicleTripValidator : AbstractValidator<CreateVehicleTripDto>
{
    public CreateVehicleTripValidator()
    {
    }
}
