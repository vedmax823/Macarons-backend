using System;
using System.Runtime.CompilerServices;
using DonMacaron.DTOs.MacaronsBoxDto;
using DonMacaron.Entities;
using DonMacaron.Mapping;
using DonMacaron.Repositories.MacaronRepository;
using DonMacaron.Repositories.MacaronsBoxRepository;
using DonMacaron.Services.UtilsService;

namespace DonMacaron.Services.MacaronsBoxService;

public class MacaronsBoxService(IMacaronsBoxRepository repository, IMacaronRepository macaronRepository) : IMacaronBoxService
{
    private readonly IMacaronsBoxRepository _repository = repository;
    private readonly IMacaronRepository _macaronRepository = macaronRepository;

    public async Task<MacaronsBoxDto> CreateMacaronsBox(CreateMacaronsBoxDto createMacaronsBoxDto)
    {
        // var newMacaron = createMacaronsBoxDto.ToEntity();
        string publicUrl = UrlService.ToUrlFriendly(createMacaronsBoxDto.Name);
        var exsistMacaronsBox = await _repository.GetMacaronsBoxByPublicUrl(publicUrl);

        if (exsistMacaronsBox is not null) throw new DuplicateWaitObjectException(publicUrl);
        var macaronsSmallSets = await this.MakeMakaronsBoxList(createMacaronsBoxDto);
        var macaronsBoxVersion = await _repository.CreateMacaronBoxVersion(createMacaronsBoxDto.ToEntity(macaronsSmallSets));
        var newMacaronBox = await _repository.CreateMacaronsBox(macaronsBoxVersion.ToMacaronBoxEnity(publicUrl));
        return newMacaronBox.ToMacaronsBoxDto();
    }

    public async Task<List<MacaronsBoxDto>> GetMacaronsBoxes()
    {
        var macaronsBoxes = await _repository.GetMacaronsBoxes();
        return macaronsBoxes.Select(m => m.ToMacaronsBoxDto()).ToList();
    }

    public async Task<MacaronsBoxDto> UpdateMacaronsBox(Guid id, CreateMacaronsBoxDto createMacaronsBoxDto)
    {
        {
            string publicUrl = UrlService.ToUrlFriendly(createMacaronsBoxDto.Name);
            var exsistMacaronsBox = await _repository.GetMacaronsBoxByPublicUrl(publicUrl);

            if (exsistMacaronsBox is not null && exsistMacaronsBox.Id != id) throw new DuplicateWaitObjectException(publicUrl);
            var macaronsBox = await _repository.GetMacaronsBoxById(id) ?? throw new NullReferenceException("Macarons box doesn't exsist");
            var macaronsSmallSets = await this.MakeMakaronsBoxList(createMacaronsBoxDto);
            var macaronsBoxVersion = await _repository.CreateMacaronBoxVersion(createMacaronsBoxDto.ToEntity(macaronsSmallSets, macaronsBox.CurrentVersion.Version + 1));
            var newMacaronBox = await _repository.UpdateMacaronsBox(macaronsBox.ToNewEntity(macaronsBoxVersion, publicUrl));
            // var newMacaron = await _repository.UpdateMacaron(macaron.NewEntity(updateMacaronDto, ingredients, publicUrl));
            return newMacaronBox.ToMacaronsBoxDto();
        }
    }


    private async Task<List<SmallMacaronsSet>> MakeMakaronsBoxList(CreateMacaronsBoxDto createMacaronsBoxDto)
    {
        List<SmallMacaronsSet> macaronsSmallSets = [];
        int count = 0;

        if (createMacaronsBoxDto.IsFixed)
        {
            List<Guid> idsSet = createMacaronsBoxDto.SmallMacaronsSets.Select(ms => ms.MacaronId).ToList();

            if (idsSet.Count == 0) throw new NullReferenceException("Macarons ids was not provided");
            List<Macaron> macaronsList = await _macaronRepository.GetMacaronsListByIds(idsSet);

            if (macaronsList.Count == 0) throw new NullReferenceException("Not correct macarons ids was provided");

            var missingIds = idsSet.Except(macaronsList.Select(m => m.Id)).ToList();
            if (missingIds.Count != 0)
            {
                throw new NullReferenceException($"The following macarons were not found: {string.Join(", ", missingIds)}");
            }

            foreach (var ms in createMacaronsBoxDto.SmallMacaronsSets)
            {
                var macaron = macaronsList.Find(m => m.Id == ms.MacaronId)
                    ?? throw new NullReferenceException("Not all macarons provided correct");

                var exsistMacaronSet = await _repository.GetSmallMacaronsSet(ms.Count, ms.MacaronId);

                if (exsistMacaronSet is null)
                {
                    macaronsSmallSets.Add(new SmallMacaronsSet { Count = ms.Count, Macaron = macaron, MacaronId = macaron.Id });
                }
                else
                {
                    macaronsSmallSets.Add(exsistMacaronSet);
                }
                count += ms.Count;
            }

            if (count != createMacaronsBoxDto.NumberOfMacarons) throw new ArgumentOutOfRangeException(nameof(createMacaronsBoxDto), "Not equal count of macarons");
        }

        return macaronsSmallSets;

    }
}

