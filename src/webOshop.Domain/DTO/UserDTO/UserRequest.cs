namespace webOshop.Domain.DTO.UserDTO;
public record UserRequest(
    string Username,
    string Email,
    string PasswordHash,
    string Address
);