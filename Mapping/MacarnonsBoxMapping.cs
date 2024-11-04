using System;
using DonMacaron.DTOs;
using DonMacaron.DTOs.MacaronsBoxDto;
using DonMacaron.Entities;
using DonMacaron.Entities.Products.Macarons;

namespace DonMacaron.Mapping;

public static class MacarnonsBoxMapping
{
    public static MacaronsBoxVersion ToEntity(this CreateMacaronsBoxDto createMacaronBoxDto, List<SmallMacaronsSet> smallMacaronsSets, int version = 1)
    {
        return new (){
            Name = createMacaronBoxDto.Name,
            Description = createMacaronBoxDto.Description,
            Price = createMacaronBoxDto.Price,
            AdvertismentPrice = createMacaronBoxDto.AdvertismentPrice,
            IsXl = createMacaronBoxDto.IsXl,
            IsCurrentlyUnavailable = createMacaronBoxDto.IsCurrentlyUnavailable,
            PictureLink = createMacaronBoxDto.PictureLink,
            NumberOfMacarons = createMacaronBoxDto.NumberOfMacarons,
            IsFixed = createMacaronBoxDto.IsFixed,
            SmallMacaronsSets = smallMacaronsSets,
            Version=version
        };
    }

    public static MacaronsBox ToMacaronBoxEnity(this MacaronsBoxVersion macaronsboxVersion, string publicUrl)
    {
        return new() {
            PublicUrl = publicUrl,
            CurrentVersionId = macaronsboxVersion.Id,
            CurrentVersion = macaronsboxVersion,
            MacaronsBoxVersions = [macaronsboxVersion]
        };
    }


    public static MacaronsBoxDto ToMacaronsBoxDto(this MacaronsBox macaronsBox)
    {
        return new MacaronsBoxDto(
            macaronsBox.Id,
            macaronsBox.CurrentVersion.Name,
            macaronsBox.CurrentVersion.Description,
            macaronsBox.CurrentVersion.PictureLink,
            macaronsBox.CurrentVersion.Price,
            macaronsBox.CurrentVersion.AdvertismentPrice,
            macaronsBox.CurrentVersion.IsXl,
            macaronsBox.CurrentVersion.IsCurrentlyUnavailable,
            macaronsBox.CurrentVersion.NumberOfMacarons,
            macaronsBox.PublicUrl,
            macaronsBox.CurrentVersion.IsFixed,
            macaronsBox.CurrentVersion.SmallMacaronsSets,
            macaronsBox.CurrentVersion.Version,
            macaronsBox.CreatedAt,
            macaronsBox.UpdatedAt
        );
    }

    public static MacaronsBox ToNewEntity(this MacaronsBox macaronsBox, MacaronsBoxVersion macaronsBoxVersion, string publicUrl)
    {
        macaronsBox.CurrentVersion = macaronsBoxVersion;
        macaronsBox.CurrentVersionId = macaronsBox.CurrentVersionId;
        macaronsBox.PublicUrl = publicUrl;
        return macaronsBox;
    }

}
