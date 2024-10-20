using System;
using DonMacaron.Data;
using DonMacaron.Entities;
using Microsoft.EntityFrameworkCore;

namespace DonMacaron.Repositories.MacaronsBoxRepository;

public class MacaronsBoxRepository(DataContext context) : IMacaronsBoxRepository
{
    private readonly DataContext _context = context;
    public async Task<List<MacaronsBox>> GetMacaronsBoxes()
    {
        return await _context.MacaronsBoxes.AsNoTracking().ToListAsync();
    }
}
