

using DonMacaron.Data;
using DonMacaron.Entities;
using Microsoft.EntityFrameworkCore;

namespace DonMacaron.Repositories.MacaronRepository;
public class MacaronRepository(DataContext context) : IMacaronRepository
{
    private readonly DataContext _context = context;

    public async Task<Macaron> CreateMacaron(Macaron macaron)
    {
        _context.Macarons.Add(macaron);
        await _context.SaveChangesAsync();
        return macaron;
    }

    public async Task<Macaron> GetMacaronById(Guid Id)
    {
        var macaron = await _context.Macarons
            .Include(m => m.Ingredients)
            .ThenInclude(i => i.Allergen)
            .SingleOrDefaultAsync(m => m.Id == Id)
            ?? throw new KeyNotFoundException();
        return macaron;
    }

    public async Task<Macaron?> GetMacaronByPublicUrl(string publicUrl)
    {
        return await _context.Macarons.FirstOrDefaultAsync(m => m.PublicUrl == publicUrl);
    }
    

    public async Task<List<Macaron>> GetMacarons()
    {
        return await _context.Macarons
                .Include(m => m.Ingredients)
                .ThenInclude(i => i.Allergen)
                .AsNoTracking()
                .ToListAsync();
    }

    public async Task<Macaron> UpdateMacaron(Macaron macaron)
    {
        _context.Macarons.Update(macaron);
        await _context.SaveChangesAsync();
        return macaron;
    }
}