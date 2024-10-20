using System;
using System.Runtime.CompilerServices;
using DonMacaron.Entities;
using DonMacaron.Repositories.MacaronsBoxRepository;

namespace DonMacaron.Services.MacaronsBoxService;

public class MacaronsBoxService(IMacaronsBoxRepository repository) : IMacaronBoxService
{
    private readonly IMacaronsBoxRepository _repository = repository;

    public async Task<List<MacaronsBox>> GetMacaronsBoxes()
    {
        return await _repository.GetMacaronsBoxes();
    }
}

