using MediatR;
using webOshop.Domain.Interfaces;

namespace webOshop.Application.Commands.Handlers;
public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductRepository _productRepository;
    public DeleteProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public Task<bool> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {

        return _productRepository.DeleteProductAsync(command.ProductId);

    }
}
