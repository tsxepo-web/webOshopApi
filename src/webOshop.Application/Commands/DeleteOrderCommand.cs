using MediatR;

namespace webOshop.Application.Commands;
public record DeleteOrderCommand(string OrderId) : IRequest<bool>;
