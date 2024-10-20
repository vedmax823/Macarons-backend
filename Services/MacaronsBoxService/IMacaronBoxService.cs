using System;
using DonMacaron.Entities;

namespace DonMacaron.Services.MacaronsBoxService;

public interface IMacaronBoxService
{
    public Task<List<MacaronsBox>> GetMacaronsBoxes();

}
