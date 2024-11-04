using System;
using DonMacaron.Data;
using DonMacaron.DTOs.MacaronsBoxDto;
using DonMacaron.Entities;
using DonMacaron.Entities.Products.Macarons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DonMacaron.Repositories.MacaronsBoxRepository;

public class MacaronsBoxRepository(DataContext context, DataContextFactory contextFactory) : IMacaronsBoxRepository
{
    private readonly DataContext _context = context;
    private readonly DataContextFactory _contextFactory = contextFactory;

    public async Task<MacaronsBox> CreateMacaronsBox(MacaronsBox macaronsBox)
    {

        _context.MacaronsBoxes.Add(macaronsBox);
        await _context.SaveChangesAsync();
        return macaronsBox;
    }

    public async Task<List<MacaronsBox>> GetMacaronsBoxes()
    {
        return await _context.MacaronsBoxes
            .Include(mb => mb.CurrentVersion)
            .ThenInclude(cr => cr.SmallMacaronsSets)
            .ThenInclude(sms => sms.Macaron)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<MacaronsBox?> GetMacaronsBoxByPublicUrl(string publicUrl)
    {
        return await _context.MacaronsBoxes.FirstOrDefaultAsync(m => m.PublicUrl == publicUrl);
    }

    public async Task<SmallMacaronsSet?> GetSmallMacaronsSet(int count, Guid macaronId)
    {
        // using var context = _contextFactory.CreateDbContext();
        // return await context.SmallMacaronsSets
        //     .AsNoTracking()
        //     .Include(sms => sms.Macaron)
        //     .FirstOrDefaultAsync(sms => sms.Count == count && sms.MacaronId == macaronId);
        return await _context.SmallMacaronsSets
            .Include(sms => sms.Macaron)
            .FirstOrDefaultAsync(sms => sms.Count == count && sms.MacaronId == macaronId);
    }

    // public async Task<List<SmallMacaronsSet>> GetSmallMacaronsSets(List<MacaronSetDto> criteria)
    // {
    //     var criteriaKeys = criteria
    //     .Select(c => new { c.Count, c.IdMacaron })
    //     .ToList();

    //     // Приєднуємо SmallMacaronsSets з criteriaKeys за умовами Count та MacaronId
    //     var result = await _context.SmallMacaronsSets
    //         .Where(sms => criteriaKeys
    //             .Any(c => c.Count == sms.Count && c.IdMacaron == sms.MacaronId))
    //         .ToListAsync();

    //     return result;

    // }

    public async Task<MacaronsBox?> GetMacaronsBoxById(Guid Id)
    {
        return await _context.MacaronsBoxes.Include(mb => mb.CurrentVersion).SingleOrDefaultAsync(mb => mb.Id == Id);
    }

    public async Task<MacaronsBox> UpdateMacaronsBox(MacaronsBox macaronsBox)
    {
        _context.MacaronsBoxes.Update(macaronsBox);
        await _context.SaveChangesAsync();
        return macaronsBox;
    }

    public async Task<MacaronsBoxVersion> CreateMacaronBoxVersion(MacaronsBoxVersion macaronsBoxVersion)
    {
        _context.MacaronsBoxVersions.Add(macaronsBoxVersion);
        await _context.SaveChangesAsync();
        return macaronsBoxVersion;
    }
}
