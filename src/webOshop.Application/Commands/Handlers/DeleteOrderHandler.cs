using MediatR;
using webOshop.Domain.Interfaces;

namespace webOshop.Application.Commands.Handlers;
public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, bool>
{
    private readonly IOrderRepository _orderRepository;
    public DeleteOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<bool> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
    {
        return await _orderRepository.DeleteOrderAsync(command.OrderId);
    }
}