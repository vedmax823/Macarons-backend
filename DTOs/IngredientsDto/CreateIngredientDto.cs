using System.ComponentModel.DataAnnotations;

namespace DonMacaron.DTOs;

public record CreateIngredientDto
(
    [Required] string Name,
    Guid? AllergenId,
    bool ContainsGluten
);
