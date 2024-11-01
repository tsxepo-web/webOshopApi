namespace webOshop.Application.DTO.ResponseDTO;
public record UserResponse(
    string Id,
    string Username,
    string Email,
    string Address
);
