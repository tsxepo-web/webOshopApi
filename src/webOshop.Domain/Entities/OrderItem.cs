namespace webOshop.Domain.Entities;
public class OrderItem
{
    public required string ProductId { get; set; }
    public string? ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}