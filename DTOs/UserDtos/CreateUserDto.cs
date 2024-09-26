using System.ComponentModel.DataAnnotations;

namespace DonMacaron.DTOs.UserDtos;

public record class CreateUserDto
(
    [Required] string Login,
    [Required] string Password,
    [Required] int[] Roles
);
