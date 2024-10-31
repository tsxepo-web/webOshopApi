namespace webOshop.Domain.DTO.ProductDTO;
public record ProductRequest(
    string Name,
    decimal Price,
    int Stock,
    string Description
);