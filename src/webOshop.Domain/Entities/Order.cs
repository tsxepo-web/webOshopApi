namespace webOshop.Domain.Entities;
public class Order
{
    public string? Id { get; set; }
    public string? UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<OrderItem> Items { get; set; } = new();
    public decimal Total { get; set; }
    public string? Status { get; set; }
}
