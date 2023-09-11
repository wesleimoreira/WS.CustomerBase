using WS.CustomerBase.Domain.Interfaces.Services;
using WS.CustomerBase.Application.Models.ViewModels;
using WS.CustomerBase.Application.Consumers.Interfaces;

namespace WS.CustomerBase.Application.Consumers.Service;
public class ProductConsumerService : IProductConsumerService
{
    private readonly IProductService _productService;
    
    public ProductConsumerService(IProductService productService)
    {
        _productService = productService;
    }
    
    public async Task<ProductViewModel> FindProductServiceAsync(int id)
    {
       var product =  await  _productService.FindProductServiceAsync(id);
       
        return new ProductViewModel(product.Id, product.Name, product.Price, product.Description, product.CreatedAt, product.UpdatedAt);
    }

    public async Task<IList<ProductViewModel>> FindAllProductServiceAsync()
    {
        var product =  await  _productService.FindAllProductServiceAsync();

        return product.Select(item => new ProductViewModel(item.Id, item.Name, item.Price, item.Description, item.CreatedAt, item.UpdatedAt)).ToList();
     }
}