using System.ComponentModel.DataAnnotations;

namespace DonMacaron.DTOs.IngredientsDto;

public record class UpdateIngredientDto
(
    [Required] string Name,
    Guid? AllergenId
);