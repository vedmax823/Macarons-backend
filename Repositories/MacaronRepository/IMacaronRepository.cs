using System;
using DonMacaron.Entities;
using DonMacaron.Entities.Products.Macarons;

namespace DonMacaron.Repositories.MacaronRepository;

public interface IMacaronRepository
{
    public Task<Macaron> CreateMacaron(Macaron macaron);
    public Task<List<Macaron>> GetMacarons();
    public Task<Macaron> GetMacaronById(Guid Id);
    public Task<Macaron> UpdateMacaron(Macaron macaron);
    public Task<Macaron?> GetMacaronByPublicUrl(string publicUrl);
    public Task<List<Macaron>> GetMacaronsListByIds(List<Guid> ids);
    public Task<MacaronsVersion> CreateMacaronsVersion(MacaronsVersion macaronsVersion);


}
