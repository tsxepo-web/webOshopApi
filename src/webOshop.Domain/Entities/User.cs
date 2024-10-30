using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webOshop.Domain.Entities;
public class User
{
    public string? Id { get; set; }
    public string? Username { get; set; }
    public string? PasswordHash { get; set; }
    public string? Role { get; set; }
}