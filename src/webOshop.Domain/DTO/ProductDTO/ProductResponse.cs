namespace webOshop.Domain.DTO.ProductDTO;
public record ProductResponse(
    string Id,
    string Name,
    decimal Price,
    int Stock,
    string Description
);