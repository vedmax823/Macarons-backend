using System;
using DonMacaron.Data;
using DonMacaron.Entities;
using Microsoft.EntityFrameworkCore;

namespace DonMacaron.Repositories.IngredientRepository;

public class IngredientRepository(DataContext context) : IIngredientRepository
{
    private readonly DataContext _context = context;

    public async Task<Ingredient> CreateIngredient(Ingredient ingredient)
    {
        _context.Ingredients.Add(ingredient);
        await _context.SaveChangesAsync();
        return ingredient;
    }

    public async Task<Ingredient?> GetIngredientById(Guid id)
    {
        return await _context.Ingredients.FindAsync(id);
    }

    public async Task<List<Ingredient>> GetIngredients()
    {
        return await _context.Ingredients.Include(a => a.Allergen).ToListAsync();
    }

    public async Task<List<Ingredient>> GetIngredientsByIds(List<Guid> ids)
    {
        if (ids == null || ids.Count == 0)
        {
            return [];
        }

        return await _context.Ingredients
            .Where(i => ids.Contains(i.Id)) 
            .ToListAsync();
    }

    public async Task<Ingredient> UpdateIngredient(Ingredient ingredient)
    {
        _context.Ingredients.Update(ingredient);
        await _context.SaveChangesAsync();
        return ingredient;
    }
}
