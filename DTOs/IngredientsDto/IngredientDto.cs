using DonMacaron.Entities;

namespace DonMacaron.DTOs.IngredientsDto;

public record class IngredientDto
(
    Guid Id,
    string Name,
    Allergen? Allergen,
    bool ContainsGluten,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt
);