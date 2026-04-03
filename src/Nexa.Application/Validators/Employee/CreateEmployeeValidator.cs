using FluentValidation;
using Nexa.Application.DTOs;

namespace Nexa.Application.Validators.Employee;

public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeDto>
{
    public CreateEmployeeValidator()
    {
    }
}
