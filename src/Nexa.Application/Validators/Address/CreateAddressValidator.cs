using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.Address;

public class CreateAddressValidator : AbstractValidator<CreateAddressDto>
{
    public CreateAddressValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O Nome é obrigatório.")
            .MaximumLength(100).WithMessage("O Nome é deve ter no máximo 100 caracters.");

        RuleFor(x => x.Street)
            .NotEmpty().WithMessage("A Rua é obrigatória.")
            .MaximumLength(100).WithMessage("A Rua é deve ter no máximo 100 caracters.");

        RuleFor(x => x.Number)
            .NotEmpty().WithMessage("O Número é obrigatório.")
            .MaximumLength(10).WithMessage("O Número é deve ter no máximo 100 caracters.");

        RuleFor(x => x.Complement)
            .MaximumLength(100).WithMessage("O Complemento é deve ter no máximo 100 caracters.");

        RuleFor(x => x.Neighborhood)
            .NotEmpty().WithMessage("O Bairro é obrigatório.")
            .MaximumLength(50).WithMessage("O Bairro é deve ter no máximo 100 caracters.");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("A Cidade é obrigatória.")
            .MaximumLength(40).WithMessage("O Cidade é deve ter no máximo 100 caracters.");

        RuleFor(x => x.State)
            .NotEmpty().WithMessage("O Estado é obrigatório.")
            .MaximumLength(40).WithMessage("O Estado é deve ter no máximo 100 caracters.");

        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("O País é obrigatório.")
            .MaximumLength(40).WithMessage("O País é deve ter no máximo 100 caracters.");

        RuleFor(x => x.ZipCode)
            .NotEmpty().WithMessage("O Códgio Postal (CEP) é obrigatório.")
            .MaximumLength(15).WithMessage("O Códgio Postal (CEP) é deve ter no máximo 100 caracters.");
    }
}
