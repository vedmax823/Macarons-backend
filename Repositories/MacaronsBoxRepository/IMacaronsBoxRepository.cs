using System;
using DonMacaron.DTOs.MacaronsBoxDto;
using DonMacaron.Entities;
using DonMacaron.Entities.Products.Macarons;

namespace DonMacaron.Repositories.MacaronsBoxRepository;

public interface IMacaronsBoxRepository
{
    public Task<List<MacaronsBox>> GetMacaronsBoxes();
    public Task<MacaronsBox> CreateMacaronsBox(MacaronsBox macaronsBox);
    public Task<MacaronsBox?> GetMacaronsBoxByPublicUrl(string publicUrl);
    public Task<SmallMacaronsSet?> GetSmallMacaronsSet(int count, Guid macaronId);
    public Task<MacaronsBox?> GetMacaronsBoxById(Guid Id);
    public Task<MacaronsBox> UpdateMacaronsBox(MacaronsBox macaronsBox);
    public Task<MacaronsBoxVersion> CreateMacaronBoxVersion(MacaronsBoxVersion macaronsBoxVersion);
    // public Task<List<SmallMacaronsSet>> GetSmallMacaronsSets(List<MacaronSetDto> criteria);
}
