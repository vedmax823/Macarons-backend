using System;
using System.Security.Cryptography;
using DonMacaron.DTOs;
using DonMacaron.Entities;
using DonMacaron.Repositories;
using DonMacaron.Repositories.AllergenRepository;
using DonMacaron.Mapping;
using DonMacaron.DTOs.IngredientsDto;
namespace DonMacaron.Services.IngredientService;

public class IngredientService(IIngredientRepository ingredientRepository, IAllergenRepository allergenRepository) : IIngredientService
{
    private readonly IIngredientRepository _ingredientRepository = ingredientRepository;
    private readonly IAllergenRepository _allergenRepository = allergenRepository;

    public async Task<Ingredient> CreateIngredient(CreateIngredientDto createIngredientDto)
    {
        Allergen? allergen = null;
        if (createIngredientDto.AllergenId.HasValue)
        {
            allergen = await _allergenRepository.GetAllergenbyId(createIngredientDto.AllergenId.Value);
        }

        return await _ingredientRepository.CreateIngredient(createIngredientDto.ToEntity(allergen));
    }

    public async Task<Ingredient> GetIngredientById(Guid id)
    {
        return await _ingredientRepository.GetIngredientById(id) ?? throw new KeyNotFoundException("Ingredient not Found");
    }

    public async Task<List<Ingredient>> GetIngredients()
    {
        return await _ingredientRepository.GetIngredients();
    }

    public async Task<List<Ingredient>> GetIngredientsListByIds(List<Guid> ids)
    {
        List<Ingredient> ingredients = await _ingredientRepository.GetIngredientsByIds(ids);
        return ingredients;
    }

    public async Task<Ingredient> UpdateIngredient(UpdateIngredientDto updateIngredientDto)
    {
        Allergen? allergen = null;
        if (updateIngredientDto.AllergenId.HasValue)
        {
            allergen = await _allergenRepository.GetAllergenbyId(updateIngredientDto.AllergenId.Value);
        }

        return await _ingredientRepository.UpdateIngredient(updateIngredientDto.ToEntity(allergen));
    }

    public async Task<Ingredient> UpdateIngredient(UpdateIngredientDto updateIngredientDto, Guid id)
    {
        Ingredient ingredient = await _ingredientRepository.GetIngredientById(id) ?? throw new KeyNotFoundException("Ingredient not found");

        Allergen? allergen = null;
        if (updateIngredientDto.AllergenId.HasValue)
        {
            allergen = await _allergenRepository.GetAllergenbyId(updateIngredientDto.AllergenId.Value);
        }
        return await _ingredientRepository.UpdateIngredient(ingredient.NewEntity(updateIngredientDto, allergen));   
    }
}
