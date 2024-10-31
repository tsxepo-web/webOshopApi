using webOshop.Domain.Entities;

namespace webOshop.Domain.Interfaces;
public interface IUserRepository
{
    Task<User> GetUserByIdAsync(string id);
    Task<User> GetUserByUsernameAsync(string username);
    Task AddUserAsync(User user);
    Task UpdateUserAsync(User user);
}
