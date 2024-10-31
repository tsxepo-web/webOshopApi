
using MongoDB.Driver;
using webOshop.Domain.Entities;
using webOshop.Domain.Interfaces;

namespace webOshop.Infrastructure.Data;
public class ProductRepository : IProductRepository
{
    private readonly IMongoCollection<Product> _products;
    public ProductRepository(MongoDbContext context)
    {
        _products = context.Products;
    }
    public async Task AddProductAsync(Product product) => await _products.InsertOneAsync(product);
    public async Task DeleteProductAsync(string id) => await _products.DeleteOneAsync(p => p.Id == id);
    public async Task<Product> GetProductByIdAsync(string id) => await _products.Find(p => p.Id == id).FirstOrDefaultAsync();
    public async Task<IEnumerable<Product>> GetProductsAsync() => await _products.Find(_ => true).ToListAsync();
    public async Task UpdateProductAsync(Product product) => await _products.ReplaceOneAsync(p => p.Id == product.Id, product);
}