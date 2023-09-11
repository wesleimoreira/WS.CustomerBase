using FluentValidation;
using WS.CustomerBase.Domain.Entities;
using WS.CustomerBase.Domain.Interfaces.Repositories;
using WS.CustomerBase.Application.Models.InputModels;
using WS.CustomerBase.Application.Consumers.Interfaces;
using WS.CustomerBase.Domain.Interfaces.Services;


namespace WS.CustomerBase.Application.Consumers.Repository;
public class ProductConsumerRepository : IProductConsumerRepository
{
    private readonly IProductService _productService;
    private readonly IProductRepository _productRepository;
    private readonly IValidator<ProductInputModel> _validator;

    public ProductConsumerRepository(IProductRepository productRepository, IProductService productService, IValidator<ProductInputModel> validator)
    {
        _validator = validator;
        _productService = productService;
        _productRepository = productRepository;
    }
    
    public async Task<bool> AddProductConsumerRepositoryAsync(ProductInputModel model)
    {
        var isProductValid = await _validator.ValidateAsync(model);

        if (!isProductValid.IsValid) return false;

        var product = new Product(model.Name, model.Price, model.Description, DateTime.Now);
        
        return await _productRepository.AddProductRepositoryAsync(product);
    }

    public async Task<bool> UpdateProductConsumerRepositoryAsync(ProductInputModel model)
    {
        var isProductValid = await _validator.ValidateAsync(model);

        if (!isProductValid.IsValid) return false;

        var product = await _productService.FindProductServiceAsync(1);
        
        if (product.Equals(null)) return false;
        
        product.UpdateProduct(model.Name, model.Price, model.Description, DateTime.Now);
        
        return await _productRepository.UpdateProductRepositoryAsync(product);
    }

    public async Task<bool> DeleteProductConsumerRepositoryAsync(ProductInputModel model)
    {
        var isProductValid = await _validator.ValidateAsync(model);

        if (!isProductValid.IsValid) return false;
        
        var product = await _productService.FindProductServiceAsync(1);

        if (product.Equals(null)) return false;
        
        return await _productRepository.DeleteProductRepositoryAsync(product);
    }
}