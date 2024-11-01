using MediatR;
using webOshop.Application.DTO.RequestDTO;
using webOshop.Application.DTO.ResponseDTO;
using webOshop.Domain.Entities;

namespace webOshop.Application.Commands;
public record CreateOrderCommand(CreateOrderRequest OrderRequest) : IRequest<OrderResponse>;
