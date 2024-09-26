using System;

namespace DonMacaron.Entities;

public class User
{
    public Guid Id { get; set; }
    public required string Login { get; set; }
    public required string PasswordHash { get; set; }
    public string RefreshToken { get; set; } = "";
    public DateTime RefreshTokenExpiryTime { get; set; }
    public List<Role> Roles { get; set; } = [];
}