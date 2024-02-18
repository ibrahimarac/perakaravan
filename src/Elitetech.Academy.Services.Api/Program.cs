
using Microsoft.EntityFrameworkCore;
using Perakaravan.CrossCutting.IoC;
using Perakaravan.Data.Context;
using Perakaravan.Services.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

#region Register Services

//Register Controllers
builder.Services.AddControllers();

//Register other layers services
NativeInjectorBootStrapper.RegisterServices(builder.Services);

//Register Db
builder.Services.AddDatabaseConfiguration(builder.Configuration);

//Register Mappings
builder.Services.AddAutoMapperConfiguration();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

#endregion

app.Run();
