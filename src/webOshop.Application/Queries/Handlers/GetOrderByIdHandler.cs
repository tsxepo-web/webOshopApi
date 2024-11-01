using MediatR;
using webOshop.Application.DTO.ResponseDTO;
using webOshop.Domain.Entities;
using webOshop.Domain.Interfaces;

namespace webOshop.Application.Queries.Handlers;
public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderResponse>
{
    private readonly IOrderRepository _orderRepository;
    public GetOrderByIdHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public async Task<OrderResponse> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetOrderByIdAsync(query.OrderId) ?? throw new KeyNotFoundException($"Order with ID {query.OrderId} was not found");
        return new OrderResponse(order.Id!, order.ProductId!, order.UserId!, order.Quantity, order.OrderDate, order.Status!);

    }
}
