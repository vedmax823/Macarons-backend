
using DonMacaron.DTOs;
using DonMacaron.Entities;
using DonMacaron.Repositories.AllergenRepository;
using DonMacaron.Mapping;
using DonMacaron.DTOs.AllergenDto;

namespace DonMacaron.Services.AllergenService;

public class AllergenService(IAllergenRepository repository) : IAllergenService
{
    private readonly IAllergenRepository _repository = repository;

    public async Task<Allergen> CreateAllergen(CreateAllergenDto createAllergenDto)
    {
        return await _repository.CreateAllergen(createAllergenDto.ToEntity());
    }

    public async Task<Allergen> GetAllergenById(Guid Id)
    {
        return await _repository.GetAllergenbyId(Id) ?? throw new KeyNotFoundException("Allergen not found");
    }

    public async Task<List<AllergenDto>> GetAllergens()
    {
        var allergens = await _repository.GetAllergens();
        return allergens.Select(a => a.ToAllergenDto()).ToList();
    }

    public async Task<Allergen> UpdateAllergen(CreateAllergenDto updateAllergenDto, Guid allergenId)
    {
        var allergen = await _repository.GetAllergenbyId(allergenId) ?? throw new KeyNotFoundException("Allergen not found");
        return await _repository.SaveAllergen(allergen.NewEntity(updateAllergenDto));
    }
}
