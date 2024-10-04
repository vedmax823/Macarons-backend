using System;
using DonMacaron.DTOs;
using DonMacaron.DTOs.AllergenDto;
using DonMacaron.Entities;

namespace DonMacaron.Services.AllergenService;

public interface IAllergenService
{
    public Task<Allergen> GetAllergenById(Guid Id);
    public Task<List<AllergenDto>> GetAllergens();
    public Task<Allergen> CreateAllergen(CreateAllergenDto createAllergenDto);
    public Task<Allergen> UpdateAllergen(CreateAllergenDto updateAllergenDto, Guid Id);
}
