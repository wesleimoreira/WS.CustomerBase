using WS.CustomerBase.Domain.Entities;

namespace WS.CustomerBase.Domain.Interfaces.Services;

public interface IProductService
{
    public Task<Product> FindProductServiceAsync(int id);
    public Task<IList<Product>> FindAllProductServiceAsync();
}