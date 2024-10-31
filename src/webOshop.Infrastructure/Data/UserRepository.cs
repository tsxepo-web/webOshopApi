using MongoDB.Driver;
using webOshop.Domain.Entities;
using webOshop.Domain.Interfaces;

namespace webOshop.Infrastructure.Data;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _users;
    public UserRepository(MongoDbContext context)
    {
        _users = context.Users;
    }
    public async Task AddUserAsync(User user) => await _users.InsertOneAsync(user);

    public async Task<User> GetUserByIdAsync(string id) => await _users.Find(u => u.Id == id).FirstOrDefaultAsync();

    public async Task<User> GetUserByUsernameAsync(string username)
    {
        return await _users.Find(u => u.Username == username).FirstOrDefaultAsync(); ;
    }

    public async Task UpdateUserAsync(User user)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Id, user.Id);
        await _users.ReplaceOneAsync(filter, user);
    }
}