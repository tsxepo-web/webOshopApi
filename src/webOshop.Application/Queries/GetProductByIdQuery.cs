using MediatR;
using webOshop.Application.DTO.ResponseDTO;

namespace webOshop.Application.Queries
{
    public record GetProductByIdQuery(string ProductId) : IRequest<ProductResponse>;
}
