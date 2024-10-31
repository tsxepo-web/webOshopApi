using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace webOshop.Domain.Entities;
public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? Category { get; set; }
    public string? ImageUrl { get; set; }
    public int InStock { get; set; }
}
