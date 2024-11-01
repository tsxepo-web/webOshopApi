using MediatR;
using webOshop.Application.DTO.ResponseDTO;
using webOshop.Domain.Entities;
using webOshop.Domain.Interfaces;

namespace webOshop.Application.Commands.Handlers;
public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, OrderResponse>
{
    private readonly IOrderRepository _orderRepository;
    public CreateOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public async Task<OrderResponse> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var order = new Order

        {
            UserId = command.OrderRequest.UserId,
            ProductId = command.OrderRequest.ProductId,
            Quantity = command.OrderRequest.Quantity,
            Status = "Pending"
        };

        await _orderRepository.CreateOrderAsync(order);
        return new OrderResponse(
            order.Id!,
            order.ProductId,
            order.UserId,
            order.Quantity,
            order.OrderDate,
            order.Status

        );

    }
}