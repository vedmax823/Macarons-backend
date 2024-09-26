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

    public async Task<Macaron> CreateMacaron(CreateMacaronDto createMacaronDto)
    {
        List<Ingredient> ingredients = await _ingredientService.GetIngredientsListByIds(createMacaronDto.IngredientsIds);
        return await _repository.CreateMacaron(createMacaronDto.ToEntity(ingredients));
    }

    public async Task<List<MacaronDto>> GetMacarons()
    {
        var macarons = await _repository.GetMacarons();

        // Мапінг даних на DTO (із списком Id інгредієнтів)
        var macaronDtos = macarons.Select(m => m.ToMacaronDto()).ToList();

        return macaronDtos;
    }

    public async Task<Macaron> GetOneById(Guid id)
    {
        return await _repository.GetMacaronById(id);
    }
}
