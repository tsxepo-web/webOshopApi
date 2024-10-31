
using webOshop.Domain.Entities;

namespace webOshop.Domain.Interfaces;

public interface IOrderRepository
{
    Task<Order> GetOrderByIdAsync(string id);
    Task<List<Order>> GetOrdersByUserIdAsync(string userId);
    Task AddOrderAsync(Order order);
    Task UpdateOrderStatusAsync(string orderId, string status);
}
