using MediatR;

namespace webOshop.Application.Commands;
public record UpdateProductCommand
(
    string ProductId,
    string Name,
    string Description,
    decimal Price,
    int InStock

) : IRequest<bool>;