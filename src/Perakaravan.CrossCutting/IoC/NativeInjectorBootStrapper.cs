using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Perakaravan.Application.Interfaces;
using Perakaravan.Application.Services;
using Perakaravan.Data.Repositories;
using Perakaravan.Domain.Repositories;
using Perakaravan.InfraPack.Domain;
using Perakaravan.InfraPack.Providers.EncryptionProvider.Implementations;
using Perakaravan.InfraPack.Providers.EncryptionProvider.Interfaces;

namespace Perakaravan.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            //Application
            services.AddScoped<ILoginUserService, LoginUserService>();

            //InfraPack
            services.AddSingleton<IEncryptionProvider, EncryptionProvider>(provider =>
            {
                return new EncryptionProvider(configuration["Application:EncryptionKey"] ?? "");
            });
            services.AddScoped(typeof(LoggedUser));

            //Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ILoginUserRepository, LoginUserRepository>();
        }
    }
}
