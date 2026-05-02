using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.Employee;

public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeDto>
{
    public UpdateEmployeeValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O Nome é obrigatório.")
            .MaximumLength(150).WithMessage("O Nome deve ter no máximo 150 caracteres.");

        RuleFor(x => x.Role)
            .NotEmpty().WithMessage("O Cargo é obrigatório.")
            .MaximumLength(100).WithMessage("O Cargo deve ter no máximo 100 caracteres.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("O Telefone é obrigatório.")
            .MaximumLength(20).WithMessage("O Telefone deve ter no máximo 20 caracteres.");

        RuleFor(x => x.HireDate)
            .NotEmpty().WithMessage("A Data de Contratação é obrigatória.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("A Data de Contratação não pode ser uma data futura.");
    }
}
