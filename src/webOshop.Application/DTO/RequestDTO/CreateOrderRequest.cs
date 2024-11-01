namespace webOshop.Application.DTO.RequestDTO;
public record CreateOrderRequest(
    string UserId,
    string ProductId,
    int Quantity
);
