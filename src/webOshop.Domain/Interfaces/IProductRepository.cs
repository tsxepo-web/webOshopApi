using webOshop.Domain.Entities;

namespace webOshop.Domain.Interfaces;
public interface IProductRepository
{
    Task<Product> GetProductByIdAsync(string id);
    Task<IEnumerable<Product>> GetProductsAsync();
    Task AddProductAsync(Product product);
    Task<bool> UpdateProductAsync(Product product);
    Task<bool> DeleteProductAsync(string id);
}
