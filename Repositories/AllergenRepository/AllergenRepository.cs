using System;
using DonMacaron.Data;
using DonMacaron.Entities;
using Microsoft.EntityFrameworkCore;

namespace DonMacaron.Repositories.AllergenRepository;

public class AllergenRepository(DataContext context) : IAllergenRepository
{
    private readonly DataContext _context = context;

    public async Task<Allergen> CreateAllergen(Allergen allergen)
    {
        _context.Allergens.Add(allergen);
        await _context.SaveChangesAsync();
        return allergen;
    }

    public async Task<Allergen?> GetAllergenbyId(Guid Id)
    {
        return await _context.Allergens.FindAsync(Id);
    }

    public Task<List<Allergen>> GetAllergens()
    {
        return _context.Allergens.ToListAsync();
    }

    public async Task<Allergen> SaveAllergen(Allergen allergen)
    {
        _context.Allergens.Update(allergen);
        await _context.SaveChangesAsync();
        return allergen;
    }
}
