using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.VehicleModel;

public class CreateVehicleModelValidator : AbstractValidator<CreateVehicleModelDto>
{
    public CreateVehicleModelValidator()
    {
    }
}
