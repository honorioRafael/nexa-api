using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.HousingRoom;

public class CreateHousingRoomValidator : AbstractValidator<CreateHousingRoomDto>
{
    public CreateHousingRoomValidator()
    {
    }
}
