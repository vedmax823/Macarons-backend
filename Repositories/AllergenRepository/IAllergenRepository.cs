using System;
using DonMacaron.Entities;

namespace DonMacaron.Repositories.AllergenRepository;

public interface IAllergenRepository
{
    public Task<List<Allergen>> GetAllergens();
    public Task<Allergen?> GetAllergenbyId(Guid Id);
    public Task<Allergen> CreateAllergen(Allergen allergen);
    public Task<Allergen> SaveAllergen(Allergen allergen);

}
