using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Perakaravan.Application.Wrapper;


namespace Perakaravan.Services.Api.ActionFilters
{
    public class ValidateModelFilter : ActionFilterAttribute
    {
        private readonly IServiceProvider _serviceProvider;

        public ValidateModelFilter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.Any())
            {
                foreach (var argument in context.ActionArguments)
                {
                    var argumentType = argument.Value.GetType();
                    var validatorGenericType = typeof(IValidator<>).MakeGenericType(argumentType);
                    var validator = _serviceProvider.GetService(validatorGenericType);
                    if(validator is not null)
                    {
                        var validationContextType = typeof(ValidationContext<>).MakeGenericType(argumentType);
                        var validationContext = (IValidationContext)Activator.CreateInstance(validationContextType, argument.Value);
                        var validateMethodType = validatorGenericType.GetMethod("Validate", new[] { validationContext.GetType() });
                        if(validateMethodType != null)
                        {
                            var validationResult = (ValidationResult)validateMethodType.Invoke(validator, new[] { validationContext });
                            if (!validationResult.IsValid)
                            {
                                var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToArray();
                                context.Result = new BadRequestObjectResult(Result.Error(errors));
                                break;
                            }
                        }     
                    }
                }                
            }
        }

    }
}
