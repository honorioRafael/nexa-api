using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.VehicleMaintenance;

public class CreateVehicleMaintenanceValidator : AbstractValidator<CreateVehicleMaintenanceDto>
{
    public CreateVehicleMaintenanceValidator()
    {
    }
}
