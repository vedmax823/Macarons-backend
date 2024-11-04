

using DonMacaron.Data;
using DonMacaron.Entities;
using DonMacaron.Entities.Products.Macarons;
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

    public async Task<MacaronsVersion> CreateMacaronsVersion(MacaronsVersion macaronsVersion)
    {
        _context.MacaronsVersions.Add(macaronsVersion);
        await _context.SaveChangesAsync();
        return macaronsVersion;
    }

    public async Task<Macaron> GetMacaronById(Guid Id)
    {
        return await _context.Macarons
            .Include(m=> m.CurrentVersion)
            .ThenInclude(cv => cv.Ingredients)
            .SingleOrDefaultAsync(m => m.Id == Id)
            ?? throw new KeyNotFoundException();
    }

    public async Task<Macaron?> GetMacaronByPublicUrl(string publicUrl)
    {
        return await _context.Macarons.Include(mv => mv.CurrentVersion).FirstOrDefaultAsync(m => m.PublicUrl == publicUrl);
    }
    

    public async Task<List<Macaron>> GetMacarons()
    {
        return await _context.Macarons
                .Include(m=> m.CurrentVersion)
                .ThenInclude(cv => cv.Ingredients)
                .ThenInclude(i => i.Allergen)
                .AsNoTracking()
                .ToListAsync();
    }

    public async Task<List<Macaron>> GetMacaronsListByIds(List<Guid> ids)
    {
        if (ids == null || ids.Count == 0)
        {
            return [];
        }

        return await _context.Macarons
            .Where(i => ids.Contains(i.Id)) 
            .ToListAsync();
    }

    public async Task<Macaron> UpdateMacaron(Macaron macaron)
    {
        _context.Macarons.Update(macaron);
        await _context.SaveChangesAsync();
        return macaron;
    }
}