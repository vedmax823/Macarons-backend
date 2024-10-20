using System;
using DonMacaron.Entities;

namespace DonMacaron.Repositories.MacaronsBoxRepository;

public interface IMacaronsBoxRepository
{
    public Task<List<MacaronsBox>> GetMacaronsBoxes();

}
