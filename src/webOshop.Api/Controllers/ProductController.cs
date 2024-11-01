using MediatR;
using Microsoft.AspNetCore.Mvc;
using webOshop.Application.Commands;
using webOshop.Application.DTO.RequestDTO;
using webOshop.Application.DTO.ResponseDTO;
using webOshop.Application.Queries;
using webOshop.Domain.Entities;
using webOshop.Domain.Interfaces;

namespace webOshop.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly IMediator _mediator;
    public ProductController(IProductRepository productRepository, IMediator mediator)
    {
        _productRepository = productRepository;
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var query = new GetAllProductsQuery();
        var products = await _mediator.Send(query);
        return Ok(products);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(string id)
    {
        try
        {
            var query = new GetProductByIdQuery(id);
            var product = await _mediator.Send(query);
            return Ok(product);
        }
        catch (System.Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] CreateProductCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetProductById), new { id = result.Id }, result);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(string id, [FromBody] UpdateProductCommand command)
    {
        if (id != command.ProductId) return BadRequest("Product ID mismatch");
        var result = await _mediator.Send(command);
        if (!result) return NotFound("Product not found.");
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        var result = await _mediator.Send(new DeleteProductCommand(id));
        if (!result) return BadRequest("Product not found.");
        return NoContent();
    }
}
