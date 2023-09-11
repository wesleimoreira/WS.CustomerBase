using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WS.CustomerBase.Application.Consumers.Interfaces;
using WS.CustomerBase.Application.Models.InputModels;

namespace WS.CustomerBase.Api.Controllers;

[ApiController]
[Route("api/product")]
public class ProductController : ControllerBase
{
    private readonly IProductConsumerService _productConsumerService;
    private readonly IProductConsumerRepository _productConsumerRepository;
    
    public ProductController(IProductConsumerService productConsumerService, IProductConsumerRepository productConsumerRepository)
    {
        _productConsumerService = productConsumerService;
        _productConsumerRepository = productConsumerRepository;
    }
    
    /// <summary>
    /// Route responsible for returning all active products. 
    /// </summary>
    /// <response code="200">The operation returned successfully.</response>
    /// <response code="400">Unexpected error</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllProduct()
    {
        try
        {
            var products = await _productConsumerService.FindAllProductServiceAsync();

            return Ok(products);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Route responsible for returning the searched product.
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">The operation returned successfully.</response>
    /// <response code="400">Unexpected error</response>
    /// <response code="404">Query not found</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetProduct(int id)
    {
        try
        {
            var product = await _productConsumerService.FindProductServiceAsync(id);

            if (product.Equals(null)) return NotFound();

            return Ok(product);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }


    [HttpPost()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostProduct(ProductInputModel model)
    {
        try
        {
            var isProductCreated = await _productConsumerRepository.AddProductConsumerRepositoryAsync(model);

            if (!isProductCreated) return NoContent();

            return Ok(model);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}