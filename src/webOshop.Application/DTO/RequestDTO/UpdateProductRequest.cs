namespace webOshop.Application.DTO.RequestDTO;
public record UpdateProductRequest(
    string Id,
    string Name,
    string Description,
    decimal Price,
    int Stock
);