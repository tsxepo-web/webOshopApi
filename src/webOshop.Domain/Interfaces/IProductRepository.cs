using webOshop.Domain.Entities;

namespace webOshop.Domain.Interfaces;
public interface IProductRepository
{
    Task<Product> GetProductByIdAsync(string id);
    Task<IEnumerable<Product>> GetProductsAsync();
    Task AddProductAsync(Product product);
    Task UpdateProductAsync(Product product);
    Task DeleteProductAsync(string id);
}
