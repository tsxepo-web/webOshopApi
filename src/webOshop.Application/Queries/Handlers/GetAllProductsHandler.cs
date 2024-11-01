using MediatR;
using webOshop.Application.DTO.ResponseDTO;
using webOshop.Domain.Interfaces;

namespace webOshop.Application.Queries.Handlers;
public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductResponse>>
{
    private readonly IProductRepository _productRepository;
    public GetAllProductsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<List<ProductResponse>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductsAsync();
        return product.Select(p => new ProductResponse(p.Id!, p.Name!, p.Price, p.InStock, p.Description!)).ToList();
    }
}