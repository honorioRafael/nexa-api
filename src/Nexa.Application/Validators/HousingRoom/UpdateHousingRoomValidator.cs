using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.HousingRoom;

public class UpdateHousingRoomValidator : AbstractValidator<UpdateHousingRoomDto>
{
    public UpdateHousingRoomValidator()
    {
    }
}
