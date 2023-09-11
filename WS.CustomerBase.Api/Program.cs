using WS.CustomerBase.Application;
using WS.CustomerBase.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

var sqlServerConnectionString = builder.Configuration.GetConnectionString("SqlServerConnectionString");

if(!string.IsNullOrEmpty(sqlServerConnectionString))
    builder.Services.AddApplicationDependencyInjection(sqlServerConnectionString);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseSwaggerConfiguration();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
