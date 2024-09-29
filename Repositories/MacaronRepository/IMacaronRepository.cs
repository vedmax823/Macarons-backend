using System;
using DonMacaron.Entities;

namespace DonMacaron.Repositories.MacaronRepository;

public interface IMacaronRepository
{
    public Task<Macaron> CreateMacaron(Macaron macaron);
    public Task<List<Macaron>> GetMacarons();
    public Task<Macaron> GetMacaronById(Guid Id);
    public Task<Macaron> UpdateMacaron(Macaron macaron);
}
