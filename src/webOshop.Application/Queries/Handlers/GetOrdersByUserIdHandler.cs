using MediatR;
using webOshop.Application.DTO.ResponseDTO;
using webOshop.Domain.Entities;
using webOshop.Domain.Interfaces;

namespace webOshop.Application.Queries.Handlers;
public class GetOrdersByUserIdHandler : IRequestHandler<GetOrdersByUserIdQuery, IEnumerable<OrderResponse>>
{
    private readonly IOrderRepository _orderRepository;
    public GetOrdersByUserIdHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<OrderResponse>> Handle(GetOrdersByUserIdQuery query, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetOrdersByUserIdAsync(query.userId);
        var orderResponses = orders.Select(order => new OrderResponse
        (
            order.Id!,
            order.ProductId!,
            order.UserId!,
            order.Quantity,
            order.OrderDate,
            order.Status!
        ));
        return orderResponses;
    }
}