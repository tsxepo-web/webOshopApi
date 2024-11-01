namespace webOshop.Application.DTO.ResponseDTO;
public record ProductResponse(
    string Id,
    string Name,
    decimal Price,
    int Stock,
    string Description
);