using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.User;

public class CreateUserValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("O email é obrigatório.")
            .MaximumLength(255).WithMessage("O email deve ter no máximo 255 caracteres.")
            .EmailAddress().WithMessage("O email informado não é válido.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("A senha é obrigatória.")
            .MinimumLength(8).WithMessage("A senha deve ter no mínimo 8 caracteres.")
            .MaximumLength(100).WithMessage("A senha deve ter no máximo 100 caracteres.");

        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("O Nome Completo é obrigatório.")
            .MaximumLength(255).WithMessage("O Nome Completo deve ter no máximo 255 caracteres.");

        RuleFor(x => x.Role)
            .NotEmpty().WithMessage("O Cargo é obrigatório.")
            .MaximumLength(100).WithMessage("O Cargo deve ter no máximo 100 caracteres.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("O Telefone é obrigatório.")
            .MaximumLength(20).WithMessage("O Telefone deve ter no máximo 20 caracteres.");

        RuleFor(x => x.HireDate)
            .NotEmpty().WithMessage("A Data de Contratação é obrigatória.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("A Data de Contratação não pode ser uma data futura.");

        RuleFor(x => x.Cpf)
            .NotEmpty().WithMessage("O CPF é obrigatório.")
            .MaximumLength(14).WithMessage("O CPF deve ter no máximo 14 caracteres.");
    }
}
