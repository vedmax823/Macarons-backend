using System;
using DonMacaron.Entities;

namespace DonMacaron.Repositories;

public interface IIngredientRepository
{
    public Task<List<Ingredient>> GetIngredients();
    public Task<Ingredient> CreateIngredient(Ingredient ingredient);
    public Task<Ingredient> UpdateIngredient(Ingredient ingredient);
    public Task<Ingredient?> GetIngredientById(Guid id);
    public Task<List<Ingredient>> GetIngredientsByIds(List<Guid> ids);

}
