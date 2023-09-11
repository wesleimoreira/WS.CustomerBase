using FluentValidation;
using WS.CustomerBase.Infrastructure;
using WS.CustomerBase.Application.Validations;
using Microsoft.Extensions.DependencyInjection;
using WS.CustomerBase.Application.Consumers.Service;
using WS.CustomerBase.Application.Consumers.Interfaces;
using WS.CustomerBase.Application.Consumers.Repository;

namespace WS.CustomerBase.Application;

public static class ApplicationDependencyInjection
{
    public static void AddApplicationDependencyInjection(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IProductConsumerService, ProductConsumerService>();
        services.AddValidatorsFromAssemblyContaining(typeof(ProductValidation));
        services.AddScoped<IProductConsumerRepository, ProductConsumerRepository>();
        
        // dependency Injection Infrastructure
        services.AddInfrastructureDependencyInjection(connectionString);
    }
}