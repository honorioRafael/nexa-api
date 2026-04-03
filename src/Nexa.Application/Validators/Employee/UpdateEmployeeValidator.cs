using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.Employee;

public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeDto>
{
    public UpdateEmployeeValidator()
    {
    }
}
