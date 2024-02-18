using Microsoft.Extensions.DependencyInjection;
using Perakaravan.Application.Constants;
using Perakaravan.Application.Interfaces;
using Perakaravan.Application.Repositories;
using Perakaravan.Application.Services;
using Perakaravan.Data.Repositories;
using Perakaravan.InfraPack.Providers.EncryptionProvider.Implementations;
using Perakaravan.InfraPack.Providers.EncryptionProvider.Interfaces;

namespace Perakaravan.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application
            services.AddScoped<ILoginUserService, LoginUserService>();

            //InfraPack
            services.AddSingleton<IEncryptionProvider, EncryptionProvider>(provider =>
            {
                return new EncryptionProvider(ApplicationConstants.EncryptionKey);
            });

            //Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ILoginUserRepository, LoginUserRepository>();
        }
    }
}
