using FluentValidation;
using Perakaravan.Application.Validators;

namespace Perakaravan.Services.Api.Configurations
{
    public static class ValidationConfig
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddValidatorsFromAssemblyContaining(typeof(LoginRequestValidator));
            services.AddScoped<IValidatorFactory, ServiceProviderValidatorFactory>();

        }
    }
}