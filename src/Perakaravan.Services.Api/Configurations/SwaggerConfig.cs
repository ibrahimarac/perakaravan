using Microsoft.OpenApi.Models;

namespace Perakaravan.Services.Api.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "", Version = "", Description = "" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Input the JWT like: Bearer {your token}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });


        }

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger(c =>
            {
#if !DEBUG
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
                var basePath = ""; // <-- nginx ingress path of values.yaml
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) => swaggerDoc.Servers = new System.Collections.Generic.List<OpenApiServer>
                {
                    new OpenApiServer { Url = $"https://{httpReq.Host.Value}{basePath}" }, 
                });
#endif
            });
            app.UseSwaggerUI(c =>
            {
#if !DEBUG
                c.SwaggerEndpoint("./swagger/v1/swagger.json", $"{""} {""}");
                c.RoutePrefix = string.Empty;
                c.DocumentTitle = "";
                c.EnableFilter();
                c.DefaultModelsExpandDepth(-1);
                c.DisplayRequestDuration();
#endif
            });
        }
    }
}