using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.VehicleMaintenance;

public class CreateVehicleMaintenanceValidator : AbstractValidator<CreateVehicleMaintenanceDto>
{
    public CreateVehicleMaintenanceValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("A Descrição é obrigatória.")
            .MaximumLength(500).WithMessage("A Descrição deve ter no máximo 500 caracteres.");

        RuleFor(x => x.Cost)
            .GreaterThanOrEqualTo(0).WithMessage("O Custo não pode ser negativo.");

        RuleFor(x => x.LastReviewDate)
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("A Data da Última Revisão não pode ser uma data futura.")
            .When(x => x.LastReviewDate.HasValue);

        RuleFor(x => x.LastReviewMileage)
            .GreaterThanOrEqualTo(0).WithMessage("A Quilometragem da Última Revisão não pode ser negativa.")
            .When(x => x.LastReviewMileage.HasValue);
    }
}
