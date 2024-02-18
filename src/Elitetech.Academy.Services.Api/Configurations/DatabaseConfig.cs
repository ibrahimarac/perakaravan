using Microsoft.EntityFrameworkCore;
using Perakaravan.Data.Context;

namespace Perakaravan.Services.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if(services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<PeraContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("PeraDbConnection"));                
            });
        }
    }
}
