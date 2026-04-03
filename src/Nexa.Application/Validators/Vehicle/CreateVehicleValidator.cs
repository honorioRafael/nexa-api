using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.Vehicle;

public class CreateVehicleValidator : AbstractValidator<CreateVehicleDto>
{
    public CreateVehicleValidator()
    {
    }
}
