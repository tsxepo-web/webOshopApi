using MediatR;
using webOshop.Application.DTO.ResponseDTO;
using webOshop.Domain.Entities;
using webOshop.Domain.Interfaces;

namespace webOshop.Application.Queries.Handlers;
public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
{
    private readonly IProductRepository _productRepository;
    public GetProductByIdHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<ProductResponse> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductByIdAsync(query.ProductId)
            ?? throw new KeyNotFoundException($"Product with ID {query.ProductId} was not found.");
        return new ProductResponse(product.Id!, product.Name!, product.Price, product.InStock, product.Description!);
    }
}
