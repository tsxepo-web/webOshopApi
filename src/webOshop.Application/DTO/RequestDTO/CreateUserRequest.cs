namespace webOshop.Application.DTO.RequestDTO;
public record CreateUserRequest(
    string Username,
    string Email,
    string PasswordHash,
    string Address
);
