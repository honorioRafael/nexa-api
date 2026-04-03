using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.VehicleTripEmployee;

public class CreateVehicleTripEmployeeValidator : AbstractValidator<CreateVehicleTripEmployeeDto>
{
    public CreateVehicleTripEmployeeValidator()
    {
    }
}
