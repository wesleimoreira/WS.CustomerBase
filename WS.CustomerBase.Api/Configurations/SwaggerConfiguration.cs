using System.Reflection;
using Microsoft.OpenApi.Models;

namespace WS.CustomerBase.Api.Configurations;

public static class SwaggerConfiguration
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "WS.CustomerBase",
                Version = "v1",
                Description = "layered architecture demonstration project",
                Contact = new OpenApiContact()
                {
                    Name = "Weslei Moreira Santana",
                    Email = "wesleimoreira600@gmail.com",
                    Url = new Uri("https://github.com/wesleiMoreira")
                },
                License = new OpenApiLicense()
                {
                    Name = "CC BY",
                    Url = new Uri("https://creativecommons.org/licenses/by/4.0")
                }
            });
            
            options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme()
            {
                In = ParameterLocation.Header,
                Description = "Authentication bearer em Json Web Token (JWT)",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference 
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "tomsAuth" 
                        }
                    }, 
                    new List<string>() 
                },
            });
                
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });
    }

    public static void UseSwaggerConfiguration(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        });
    }
}