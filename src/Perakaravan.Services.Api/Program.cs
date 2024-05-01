using Microsoft.EntityFrameworkCore;
using Perakaravan.CrossCutting.IoC;
using Perakaravan.Data.Context;
using Perakaravan.Services.Api.ActionFilters;
using Perakaravan.Services.Api.Configurations;
using Perakaravan.Services.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

#region Register Services

//Register Controllers
builder.Services.AddControllers(opt =>
{
    opt.Filters.Add<ValidateModelFilter>();
});

//JWT
builder.Services.AddJwtConfiguration(builder.Configuration);

//Register other layers services
NativeInjectorBootStrapper.RegisterServices(builder.Services, builder.Configuration);

//Register Db
builder.Services.AddDatabaseConfiguration(builder.Configuration);

//Register Mappings
builder.Services.AddAutoMapperConfiguration();

//FluentValidation
builder.Services.AddFluentValidationConfiguration();

// Swagger Config
builder.Services.AddSwaggerConfiguration();

#endregion

var app = builder.Build();

#region Database Seed

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<PeraContext>();
    dbContext.Database.Migrate();
}

#endregion

#region Register Middlawares

app.UseDeveloperExceptionPage();

app.UseSwaggerSetup();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseSetLoggedUserMiddleware();

app.UseAuthorization();

app.MapControllers();

#endregion

app.Run();
