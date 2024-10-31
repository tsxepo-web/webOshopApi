
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

    public async Task AddOrderAsync(Order order)
    {
        await _orders.InsertOneAsync(order);
    }

    public Task<Order> GetOrderByIdAsync(string id) => _orders.Find(o => o.Id == id).FirstOrDefaultAsync();

    public Task<List<Order>> GetOrdersByUserIdAsync(string userId)
    {
        return _orders.Find(o => o.UserId == userId).ToListAsync();
    }

    public async Task UpdateOrderStatusAsync(string orderId, string status)
    {
        var update = Builders<Order>.Update.Set(o => o.Status, status);
        await _orders.UpdateOneAsync(o => o.Id == orderId, update);
    }
}
