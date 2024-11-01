namespace webOshop.Application.DTO.ResponseDTO;
public record OrderResponse(
    string Id,
    string ProductId,
    string UserId,
    int Quantity,
    DateTime OrderDate,
    string Status
);
