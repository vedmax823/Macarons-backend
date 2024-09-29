using System.ComponentModel.DataAnnotations;

namespace DonMacaron.DTOs;

public record class CreateAllergenDto
(
    [Required] string Name,
    string Link
);