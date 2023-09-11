using Microsoft.EntityFrameworkCore;
using WS.CustomerBase.Domain.Entities; 
using WS.CustomerBase.Infrastructure.Context;
using WS.CustomerBase.Domain.Interfaces.Services;
namespace WS.CustomerBase.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly SqlServerDbContext _dbContext;
    
    public ProductService(SqlServerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product> FindProductServiceAsync(int id)
    {
        return await _dbContext.Products.Where(x => x.Id == id).AsNoTracking().FirstAsync();
    }

    public async Task<IList<Product>> FindAllProductServiceAsync()
    {
        return await _dbContext.Products.AsNoTracking().ToListAsync();
    }
}