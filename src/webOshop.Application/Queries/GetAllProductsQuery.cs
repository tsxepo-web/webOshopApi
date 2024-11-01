using MediatR;
using webOshop.Application.DTO.ResponseDTO;

namespace webOshop.Application.Queries;
public record GetAllProductsQuery : IRequest<List<ProductResponse>>;