using DonMacaron.DTOs;
using DonMacaron.DTOs.MacaronsDto;
using DonMacaron.Entities;
using DonMacaron.Mapping;
using DonMacaron.Repositories.MacaronRepository;
using DonMacaron.Services.IngredientService;

namespace DonMacaron.Services.MacaronService;

public class MacaronService(IMacaronRepository repository, IIngredientService ingredientService) : IMacaronService
{
    private readonly IMacaronRepository _repository = repository;
    private readonly IIngredientService _ingredientService = ingredientService;

    public async Task<MacaronDto> CreateMacaron(CreateMacaronDto createMacaronDto)
    {
        List<Ingredient> ingredients = await _ingredientService.GetIngredientsListByIds(createMacaronDto.IngredientsIds);
        var macaron = await _repository.CreateMacaron(createMacaronDto.ToEntity(ingredients));
        return macaron.ToMacaronDto();
    }

    public async Task<List<MacaronDto>> GetMacarons()
    {
        var macarons = await _repository.GetMacarons();
        return macarons.Select(m => m.ToMacaronDto()).ToList();
    }

    public async Task<Macaron> GetOneById(Guid id)
    {
        return await _repository.GetMacaronById(id);
    }

    public async Task<MacaronDto> UpdateMacaron(Guid id, CreateMacaronDto updateMacaronDto)
    {
        var macaron = await _repository.GetMacaronById(id) ?? throw new KeyNotFoundException("Macaron doesn't exsist");
        List<Ingredient> ingredients = await _ingredientService.GetIngredientsListByIds(updateMacaronDto.IngredientsIds);
        var newMacaron = await _repository.UpdateMacaron(macaron.NewEntity(updateMacaronDto, ingredients));
        return newMacaron.ToMacaronDto();
    }
}
