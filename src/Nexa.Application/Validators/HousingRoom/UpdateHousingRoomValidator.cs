using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.HousingRoom;

public class UpdateHousingRoomValidator : AbstractValidator<UpdateHousingRoomDto>
{
    public UpdateHousingRoomValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O Nome é obrigatório.")
            .MaximumLength(100).WithMessage("O Nome deve ter no máximo 100 caracteres.");

        RuleFor(x => x.HousingRoomType)
            .IsInEnum().WithMessage("O Tipo do Quarto informado é inválido.");

        RuleFor(x => x.Capacity)
            .GreaterThan(0).WithMessage("A Capacidade deve ser maior que 0.");
    }
}
