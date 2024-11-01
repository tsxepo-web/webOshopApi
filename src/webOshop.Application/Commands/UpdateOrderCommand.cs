using MediatR;
using webOshop.Domain.Entities;

namespace webOshop.Application.Commands;
public record UpdateOrderCommand(string OrderId, string Status) : IRequest<bool>;
