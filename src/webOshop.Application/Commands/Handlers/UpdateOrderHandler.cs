
using MediatR;
using webOshop.Domain.Interfaces;

namespace webOshop.Application.Commands.Handlers;
public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, bool>
{
    private readonly IOrderRepository _orderRepository;
    public UpdateOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<bool> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
    {
        return await _orderRepository.UpdateOrderStatusAsync(command.OrderId, command.Status);
    }
}