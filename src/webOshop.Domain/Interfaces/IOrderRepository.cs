
using webOshop.Domain.Entities;

namespace webOshop.Domain.Interfaces;

public interface IOrderRepository
{
    Task<Order?> GetOrderByIdAsync(string id);
    Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId);
    Task<Order> CreateOrderAsync(Order order);
    Task<bool> UpdateOrderStatusAsync(string orderId, string status);
    Task<bool> DeleteOrderAsync(string orderId);
}
