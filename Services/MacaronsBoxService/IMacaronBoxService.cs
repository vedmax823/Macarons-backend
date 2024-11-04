using System;
using DonMacaron.DTOs.MacaronsBoxDto;
using DonMacaron.DTOs.MacaronsDto;
using DonMacaron.Entities;

namespace DonMacaron.Services.MacaronsBoxService;

public interface IMacaronBoxService
{
    public Task<List<MacaronsBoxDto>> GetMacaronsBoxes();
    public Task<MacaronsBoxDto> CreateMacaronsBox(CreateMacaronsBoxDto createMacaronsBoxDto);
    public Task<MacaronsBoxDto> UpdateMacaronsBox(Guid id, CreateMacaronsBoxDto createMacaronsBoxDto);

}
