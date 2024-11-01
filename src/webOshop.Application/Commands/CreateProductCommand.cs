
using MediatR;
using webOshop.Application.DTO.ResponseDTO;

namespace webOshop.Application.Commands;
public record CreateProductCommand(
    string Name,
    string Description,
    decimal Price,
    int Stock
    ) : IRequest<ProductResponse>;
