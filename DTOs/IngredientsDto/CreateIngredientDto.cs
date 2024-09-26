using System.ComponentModel.DataAnnotations;

namespace DonMacaron.DTOs;

public record class CreateIngredientDto
(
    [Required] string Name,
    Guid? AllergenId
);
