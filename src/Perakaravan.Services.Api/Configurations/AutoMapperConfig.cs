using AutoMapper;
using Perakaravan.Application.Automapper;

namespace Perakaravan.Services.Api.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSingleton(provider =>new MapperConfiguration(cfg =>
                {
                    var configuration = provider.GetRequiredService<IConfiguration>();

                    cfg.AddProfile(new DomainToDtoMappingProfiler(configuration));
                    cfg.AddProfile(new DtoToDomainMappingProfiler());
                }).CreateMapper());

        }
    }
}