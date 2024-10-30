namespace webOshop.Domain.Entities;
public class CartItem
{
    public required string ProductId { get; set; }
    public int Quantity { get; set; }
}
