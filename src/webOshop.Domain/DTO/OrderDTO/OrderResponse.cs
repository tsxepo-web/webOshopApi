namespace webOshop.Domain.DTO.OrderDTO;
public record OrderResponse(
    string Id,
    string UserId,
    string ProductId,
    int Quantity,
    DateTime OrderDate
);
