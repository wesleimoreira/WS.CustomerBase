using WS.CustomerBase.Application.Models.ViewModels;

namespace WS.CustomerBase.Application.Consumers.Interfaces;

public interface IProductConsumerService
{
    public Task<ProductViewModel> FindProductServiceAsync(int id);
    public Task<IList<ProductViewModel>> FindAllProductServiceAsync();
}