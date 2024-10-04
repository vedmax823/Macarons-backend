using System;
using DonMacaron.DTOs;
using DonMacaron.DTOs.MacaronsDto;
using DonMacaron.Entities;

namespace DonMacaron.Services;

public interface IMacaronService
{
    public Task<MacaronDto> CreateMacaron(CreateMacaronDto createMacaronDto);
    public Task<List<MacaronDto>> GetMacarons();
    public Task<MacaronDto> GetOneByPublicUrl(string publicUrl);
    public Task<MacaronDto> UpdateMacaron(Guid id,  CreateMacaronDto createMacaronDto);

}
