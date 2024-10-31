namespace webOshop.Domain.DTO.OrderDTO;
public record OrderRequest(
    string UserId,
    string ProductId,
    int Quantity
);
