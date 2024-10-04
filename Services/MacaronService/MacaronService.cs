using DonMacaron.DTOs;
using DonMacaron.DTOs.MacaronsDto;
using DonMacaron.Entities;
using DonMacaron.Mapping;
using DonMacaron.Repositories.MacaronRepository;
using DonMacaron.Services.IngredientService;
using DonMacaron.Services.UtilsService;

namespace DonMacaron.Services.MacaronService;

public class MacaronService(IMacaronRepository repository, IIngredientService ingredientService) : IMacaronService
{
    private readonly IMacaronRepository _repository = repository;
    private readonly IIngredientService _ingredientService = ingredientService;

    public async Task<MacaronDto> CreateMacaron(CreateMacaronDto createMacaronDto)
    {
        string publicUrl = UrlService.ToUrlFriendly(createMacaronDto.Taste);
        var exsistMacaron = await _repository.GetMacaronByPublicUrl(publicUrl);

        if (exsistMacaron is not null) throw new DuplicateWaitObjectException(publicUrl);
        List<Ingredient> ingredients = await _ingredientService.GetIngredientsListByIds(createMacaronDto.IngredientsIds);
        var macaron = await _repository.CreateMacaron(createMacaronDto.ToEntity(ingredients, publicUrl));
        return macaron.ToMacaronDto();
    }

    public async Task<List<MacaronDto>> GetMacarons()
    {
        var macarons = await _repository.GetMacarons();
        return macarons.Select(m => m.ToMacaronDto()).ToList();
    }

    public async Task<MacaronDto> GetOneByPublicUrl(string publicUrl)
    {
        var macaron = await _repository.GetMacaronByPublicUrl(publicUrl) 
            ?? throw new KeyNotFoundException();
        return macaron.ToMacaronDto();
    }

    public async Task<MacaronDto> UpdateMacaron(Guid id, CreateMacaronDto updateMacaronDto)
    {
        string publicUrl = UrlService.ToUrlFriendly(updateMacaronDto.Taste);
        var exsistMacaron = await _repository.GetMacaronByPublicUrl(publicUrl);

        if (exsistMacaron is not null && exsistMacaron.Id != id) throw new DuplicateWaitObjectException(publicUrl);
        var macaron = await _repository.GetMacaronById(id) ?? throw new KeyNotFoundException("Macaron doesn't exsist");
        List<Ingredient> ingredients = await _ingredientService.GetIngredientsListByIds(updateMacaronDto.IngredientsIds);
        var newMacaron = await _repository.UpdateMacaron(macaron.NewEntity(updateMacaronDto, ingredients, publicUrl));
        return newMacaron.ToMacaronDto();
    }
}
