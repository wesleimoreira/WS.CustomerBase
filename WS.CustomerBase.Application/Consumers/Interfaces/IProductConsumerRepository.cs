using FluentValidation;
using WS.CustomerBase.Application.Models.InputModels;

namespace WS.CustomerBase.Application.Consumers.Interfaces;
public interface IProductConsumerRepository
{
    public Task<bool> AddProductConsumerRepositoryAsync(ProductInputModel model);
    public Task<bool> UpdateProductConsumerRepositoryAsync(ProductInputModel model);
    public Task<bool> DeleteProductConsumerRepositoryAsync(ProductInputModel model);
}