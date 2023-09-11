using WS.CustomerBase.Domain.Entities;
using WS.CustomerBase.Infrastructure.Context;
using WS.CustomerBase.Domain.Interfaces.Repositories;

namespace WS.CustomerBase.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly SqlServerDbContext _dbContext;
    
    public ProductRepository(SqlServerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<bool> AddProductRepositoryAsync(Product product)
    {
        _dbContext.Products.Add(product);

        return (await _dbContext.SaveChangesAsync() > 0);
    }

    public async Task<bool> UpdateProductRepositoryAsync(Product product)
    {
        _dbContext.Products.Update(product);

        return (await _dbContext.SaveChangesAsync() > 0);
    }

    public async Task<bool> DeleteProductRepositoryAsync(Product product)
    {
        _dbContext.Products.Remove(product);

        return (await _dbContext.SaveChangesAsync() > 0);
    }
}