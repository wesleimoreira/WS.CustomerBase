using WS.CustomerBase.Domain.Entities;

namespace WS.CustomerBase.Domain.Interfaces.Repositories;

public interface IProductRepository
{
    public Task<bool> AddProductRepositoryAsync(Product product);
    public Task<bool> UpdateProductRepositoryAsync(Product product);
    public Task<bool> DeleteProductRepositoryAsync(Product product);
}