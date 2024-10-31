using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace webOshop.Domain.Entities;
public class Order
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? UserId { get; set; }
    public string? ProductId { get; set; }
    public DateTime OrderDate { get; set; }
    public int Quantity { get; set; }
    public string? Status { get; set; }
}
