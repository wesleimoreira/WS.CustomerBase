using Microsoft.EntityFrameworkCore;
using WS.CustomerBase.Infrastructure.Context;
using WS.CustomerBase.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using WS.CustomerBase.Domain.Interfaces.Services;
using WS.CustomerBase.Infrastructure.Repositories;
using WS.CustomerBase.Domain.Interfaces.Repositories;

namespace WS.CustomerBase.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static void AddInfrastructureDependencyInjection(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<SqlServerDbContext>(option =>
        {
            option.UseSqlServer(connectionString);
        });
        
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductRepository, ProductRepository>();
    }
}