
using DonMacaron.DTOs;
using DonMacaron.DTOs.IngredientsDto;
using DonMacaron.Entities;

namespace DonMacaron.Mapping;

public static class IngredientMapping
{
    public static Ingredient ToEntity(this CreateIngredientDto createIngredientDto, Allergen? allergen)
    {
        return new Ingredient
        {
            Name = createIngredientDto.Name,
            Allergen = allergen,
            ContainsGluten = createIngredientDto.ContainsGluten
        };
    }

    public static Ingredient ToEntity(this UpdateIngredientDto updateIngredientDto, Allergen? allergen)
    {
        return new Ingredient
        {
            Name = updateIngredientDto.Name,
            Allergen = allergen,
            ContainsGluten = updateIngredientDto.ContainsGluten
        };
    }

    public static Ingredient NewEntity(this Ingredient ingredient, UpdateIngredientDto updateIngredientDto, Allergen? allergen = null)
    {
        ingredient.Name = updateIngredientDto.Name;
        ingredient.Allergen = allergen;
        ingredient.ContainsGluten = updateIngredientDto.ContainsGluten;
        return ingredient;
    }

    public static IngredientDto ToDto(this Ingredient ingredient)
    {
        return new IngredientDto(
        ingredient.Id,           // Guid
        ingredient.Name,         // string
        ingredient.Allergen,     // Allergen
        ingredient.ContainsGluten, // bool
        ingredient.CreatedAt,
        ingredient.UpdatedAt
    );
    }
}
