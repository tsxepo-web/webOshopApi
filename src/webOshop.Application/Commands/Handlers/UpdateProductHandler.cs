using MediatR;
using webOshop.Domain.Interfaces;

namespace webOshop.Application.Commands.Handlers;
public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository _productRepository;
    public UpdateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<bool> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductByIdAsync(command.ProductId);
        if (product == null) return false;

        product.Name = command.Name;
        product.Description = command.Description;
        product.Price = command.Price;
        product.InStock = command.InStock;

        return await _productRepository.UpdateProductAsync(product);
    }
}