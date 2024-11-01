using MediatR;
using webOshop.Application.DTO.ResponseDTO;
using webOshop.Domain.Entities;

namespace webOshop.Application.Queries;
public record GetOrderByIdQuery(string OrderId) : IRequest<OrderResponse>;