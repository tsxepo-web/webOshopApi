using Microsoft.AspNetCore.Mvc;
using webOshop.Domain.DTO.ProductDTO;
using webOshop.Domain.Entities;
using webOshop.Domain.Interfaces;

namespace webOshop.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products = await _productRepository.GetProductsAsync();
        return Ok(products);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(string id)
    {
        var product = await _productRepository.GetProductByIdAsync(id);
        return product == null ? NotFound() : Ok(product);
    }
    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] ProductRequest productRequest)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var product = new Product
        {
            Name = productRequest.Name,
            Price = productRequest.Price,
            InStock = productRequest.Stock,
            Description = productRequest.Description
        };

        await _productRepository.AddProductAsync(product);
        var response = new ProductResponse(
        Id: product.Id!,
        Name: product.Name,
        Price: product.Price,
        Stock: product.InStock,
        Description: product.Description
    );
        return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, response);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(string id, [FromBody] Product product)
    {
        if (id != product.Id) return BadRequest("Product ID mismatch");
        await _productRepository.UpdateProductAsync(product);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        await _productRepository.DeleteProductAsync(id);
        return NoContent();
    }
}
