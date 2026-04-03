using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.Address;

public class UpdateAddressValidator : AbstractValidator<UpdateAddressDto>
{
    public UpdateAddressValidator()
    {
    }
}
