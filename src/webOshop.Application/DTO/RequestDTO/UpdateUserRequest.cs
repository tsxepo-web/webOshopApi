namespace webOshop.Application.DTO.RequestDTO;
public record UpdateUserRequest
(
    string Username,
    string Email,
    string PasswordHash,
    string Address
);