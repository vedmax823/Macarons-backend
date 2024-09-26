
using DonMacaron.DTOs;
using DonMacaron.DTOs.IngredientsDto;
using DonMacaron.Entities;

namespace DonMacaron.Mapping;

public static class IngredientMapping
{
    public static Ingredient ToEntity(this CreateIngredientDto createIngredientDto, Allergen? allergen)
    {
        return new Ingredient{
            Name = createIngredientDto.Name,
            Allergen = allergen
        };
    }

    public static Ingredient ToEntity(this UpdateIngredientDto updateIngredientDto, Allergen? allergen)
    {
        return new Ingredient{
            Name = updateIngredientDto.Name,
            Allergen = allergen
        };
    }

    public static Ingredient NewEntity(this Ingredient ingredient, UpdateIngredientDto updateIngredientDto, Allergen? allergen = null)
    {
        ingredient.Name = updateIngredientDto.Name;
        ingredient.Allergen = allergen;
        return ingredient;
    }
}
