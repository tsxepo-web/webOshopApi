using MediatR;
using webOshop.Application.DTO.ResponseDTO;
using webOshop.Domain.Entities;

namespace webOshop.Application.Queries;
public record GetOrdersByUserIdQuery(string userId) : IRequest<IEnumerable<OrderResponse>>;