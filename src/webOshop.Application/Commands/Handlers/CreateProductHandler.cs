
using MediatR;
using webOshop.Application.DTO.ResponseDTO;
using webOshop.Domain.Entities;
using webOshop.Domain.Interfaces;

namespace webOshop.Application.Commands.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResponse>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductResponse> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = command.Name,
                Description = command.Description,
                Price = command.Price,
                InStock = command.Stock,
            };
            await _productRepository.AddProductAsync(product);
            return new ProductResponse(product.Id!, product.Name, product.Price, product.InStock, product.Description);
        }
    }
}