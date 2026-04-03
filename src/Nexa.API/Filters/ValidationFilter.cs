using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Nexa.API.Filters;

public class ValidationFilter : IAsyncActionFilter
{
    private readonly IServiceProvider _serviceProvider;

    public ValidationFilter(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        foreach (var argument in context.ActionArguments.Values)
        {
            if (argument is null) continue;

            var argumentType = argument.GetType();

            // Lists
            if (argumentType.IsGenericType && argumentType.GetGenericTypeDefinition() == typeof(List<>))
            {
                var itemType = argumentType.GetGenericArguments()[0];
                var validatorType = typeof(IValidator<>).MakeGenericType(itemType);
                var validator = _serviceProvider.GetService(validatorType) as IValidator;

                if (validator is null) continue;

                foreach (var item in (IEnumerable<object>)argument)
                {
                    var validationContext = new ValidationContext<object>(item);
                    var result = await validator.ValidateAsync(validationContext);

                    if (!result.IsValid)
                    {
                        context.Result = BuildBadRequest(result.Errors.Select(e => e.ErrorMessage));
                        return;
                    }
                }

                continue;
            }

            // General objects
            {
                var validatorType = typeof(IValidator<>).MakeGenericType(argumentType);
                var validator = _serviceProvider.GetService(validatorType) as IValidator;

                if (validator is null) continue;

                var validationContext = new ValidationContext<object>(argument);
                var result = await validator.ValidateAsync(validationContext);

                if (!result.IsValid)
                {
                    context.Result = BuildBadRequest(result.Errors.Select(e => e.ErrorMessage));
                    return;
                }
            }
        }

        await next();
    }

    private static BadRequestObjectResult BuildBadRequest(IEnumerable<string> errors)
    {
        return new BadRequestObjectResult(new
        {
            message = "Validação falhou",
            errors
        });
    }
}
