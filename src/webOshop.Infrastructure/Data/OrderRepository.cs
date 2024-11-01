using MongoDB.Driver;
using webOshop.Domain.Entities;
using webOshop.Domain.Interfaces;

namespace webOshop.Infrastructure.Data;
public class OrderRepository : IOrderRepository
{
    private readonly IMongoCollection<Order> _orders;
    public OrderRepository(MongoDbContext context)
    {
        _orders = context.Orders;
    }

    public async Task<Order> CreateOrderAsync(Order order)
    {
        await _orders.InsertOneAsync(order);
        return order;
    }

    public async Task<bool> DeleteOrderAsync(string orderId)
    {
        var deleteResult = await _orders.DeleteOneAsync(o => o.Id == orderId);
        return deleteResult.DeletedCount > 0;
    }

    public async Task<Order?> GetOrderByIdAsync(string OrderId)
    {
        return await _orders.Find(o => o.Id == OrderId).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId)
    {
        return await _orders.Find(o => o.UserId == userId).ToListAsync();
    }

    public async Task<bool> UpdateOrderStatusAsync(string orderId, string status)
    {
        var updatedResult = await _orders.UpdateOneAsync(
            o => o.Id == orderId,
            Builders<Order>.Update.Set(o => o.Status, status)
        );
        return updatedResult.ModifiedCount > 0;
    }
}
