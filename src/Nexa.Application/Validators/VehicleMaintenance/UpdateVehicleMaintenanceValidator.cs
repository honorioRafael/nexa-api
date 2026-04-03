using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.VehicleMaintenance;

public class UpdateVehicleMaintenanceValidator : AbstractValidator<UpdateVehicleMaintenanceDto>
{
    public UpdateVehicleMaintenanceValidator()
    {
    }
}
