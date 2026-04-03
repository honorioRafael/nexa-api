using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.VehicleModel;

public class UpdateVehicleModelValidator : AbstractValidator<UpdateVehicleModelDto>
{
    public UpdateVehicleModelValidator()
    {
    }
}
