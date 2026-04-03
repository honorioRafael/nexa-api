using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.Vehicle;

public class UpdateVehicleValidator : AbstractValidator<UpdateVehicleDto>
{
    public UpdateVehicleValidator()
    {
    }
}
