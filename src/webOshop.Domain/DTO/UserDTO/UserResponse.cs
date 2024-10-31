using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webOshop.Domain.DTO.UserDTO;
public record UserResponse(
    string Id,
    string UserName,
    string Email,
    string Address
);