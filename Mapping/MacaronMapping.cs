using System;
using DonMacaron.DTOs;
using DonMacaron.DTOs.MacaronsDto;
using DonMacaron.Entities;
using DonMacaron.Entities.Products.Macarons;

namespace DonMacaron.Mapping;

public static class MacaronMapping
{
    public static MacaronsVersion ToEntity(this CreateMacaronDto createMacaronDto, List<Ingredient> ingredients, int version = 1)
    {
        return new()
        {
            Taste = createMacaronDto.Taste,
            Description = createMacaronDto.Description,
            Price = createMacaronDto.Price,
            AdvertismentPrice = createMacaronDto.AdvertismentPrice,
            IsXl = createMacaronDto.IsXl,
            IsCurrentlyAvailable = createMacaronDto.IsCurrentlyAvailable,
            PictureLink = createMacaronDto.PictureLink,
            Ingredients = ingredients,
            Version = version
        };
    }

    public static Macaron ToMacaronEnity(this MacaronsVersion macaronsVersion, string publicUrl)
    {
        return new() {
            PublicUrl = publicUrl,
            CurrentVersionId = macaronsVersion.Id,
            CurrentVersion = macaronsVersion,
            MacaronsVersions = [macaronsVersion]
        };
    }

    public static MacaronDto ToMacaronDto(this Macaron m)
    {
        return new()
        {
            Id = m.Id,
            Taste = m.CurrentVersion.Taste,
            PictureLink = m.CurrentVersion.PictureLink,
            Price = m.CurrentVersion.Price,
            AdvertismentPrice = m.CurrentVersion.AdvertismentPrice,
            Description = m.CurrentVersion.Description,
            IngredientsIds = m.CurrentVersion.Ingredients.Select(i => i.Id).ToArray(),
            IsXl = m.CurrentVersion.IsXl,
            IsCurrentlyUnavailable = m.CurrentVersion.IsCurrentlyAvailable,
            CreatedAt = m.CreatedAt,
            UpdatedAt = m.UpdatedAt,
            PublicUrl = m.PublicUrl
        };
    }

    public static Macaron ToNewEntity(this Macaron macaron, MacaronsVersion macaronsVersion, string publicUrl)
    {
        macaron.CurrentVersionId = macaronsVersion.Id;
        macaron.PublicUrl = publicUrl;
        macaron.CurrentVersion = macaronsVersion;
        macaron.MacaronsVersions.Add(macaronsVersion);

        return macaron;
    }
}
