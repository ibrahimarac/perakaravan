using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Perakaravan.Application.Wrapper;


namespace Perakaravan.Services.Api.ActionFilters
{
    public class ValidateModelFilter : ActionFilterAttribute
    {
        private readonly IValidatorFactory _validatorFactory;

        public ValidateModelFilter(IValidatorFactory validatorFactory)
        {
            _validatorFactory = validatorFactory;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.Any())
            {
                foreach (var argument in context.ActionArguments)
                {
                    var validator = _validatorFactory.GetValidator(argument.Value.GetType());
                    if(validator is not null)
                    {
                        var validationContextType = typeof(ValidationContext<>).MakeGenericType(argument.Value.GetType());
                        var validationContext = (IValidationContext)Activator.CreateInstance(validationContextType, argument.Value);
                        var validationResult = validator.Validate(validationContext);
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
