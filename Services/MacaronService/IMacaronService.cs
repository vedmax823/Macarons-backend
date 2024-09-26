using System;
using DonMacaron.DTOs;
using DonMacaron.DTOs.MacaronsDto;
using DonMacaron.Entities;

namespace DonMacaron.Services;

public interface IMacaronService
{
    public Task<Macaron> CreateMacaron(CreateMacaronDto createMacaronDto);
    public Task<List<MacaronDto>> GetMacarons();
    public Task<Macaron> GetOneById(Guid id);

}
