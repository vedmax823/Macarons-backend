using System;
using DonMacaron.DTOs;
using DonMacaron.DTOs.IngredientsDto;
using DonMacaron.Entities;

namespace DonMacaron.Services.IngredientService;

public interface IIngredientService
{
    public Task<List<IngredientDto>> GetIngredients();
    public Task<Ingredient> CreateIngredient(CreateIngredientDto createIngredientDto);
    public Task<Ingredient> UpdateIngredient(UpdateIngredientDto updateIngredientDto, Guid id);
    public Task<Ingredient> GetIngredientById(Guid id);
    public Task<List<Ingredient>> GetIngredientsListByIds(List<Guid> ids);
}
