using System;
using DonMacaron.DTOs;
using DonMacaron.DTOs.MacaronsDto;
using DonMacaron.Entities;

namespace DonMacaron.Mapping;

public static class MacaronMapping
{
    public static Macaron ToEntity(this CreateMacaronDto createMacaronDto, List<Ingredient> ingredients, string publicUrl)
    {

        return new Macaron{
            Taste = createMacaronDto.Taste,
            Description = createMacaronDto.Description,
            Price = createMacaronDto.Price,
            AdvertismentPrice = createMacaronDto.AdvertismentPrice,
            IsXl = createMacaronDto.IsXl,
            IsCurrentlyUnavailable = createMacaronDto.IsCurrentlyUnavailable,
            PictureLink = createMacaronDto.PictureLink,
            Ingredients = ingredients,
            PublicUrl = publicUrl
        };
    }

    public static MacaronDto ToMacaronDto(this Macaron m)
    {
        return new()
        {
            Id = m.Id,
            Taste = m.Taste,
            PictureLink = m.PictureLink,
            Price = m.Price,
            AdvertismentPrice = m.AdvertismentPrice,
            Description = m.Description,
            IngredientsIds = m.Ingredients.Select(i => i.Id).ToArray(),
            IsXl = m.IsXl,
            IsCurrentlyUnavailable = m.IsCurrentlyUnavailable,
            CreatedAt = m.CreatedAt,
            UpdatedAt = m.UpdatedAt,
            PublicUrl = m.PublicUrl
        };
    }

    public static Macaron NewEntity(this Macaron macaron, CreateMacaronDto createMacaronDto, List<Ingredient> ingredients, string publicUrl)
    {
        macaron.Taste = createMacaronDto.Taste;
        macaron.Ingredients = ingredients;
        macaron.PictureLink = createMacaronDto.PictureLink;
        macaron.Price = createMacaronDto.Price;
        macaron.AdvertismentPrice = createMacaronDto.AdvertismentPrice;
        macaron.Description = createMacaronDto.Description;
        macaron.IsXl = createMacaronDto.IsXl;
        macaron.IsCurrentlyUnavailable = createMacaronDto.IsCurrentlyUnavailable;
        macaron.PublicUrl = publicUrl;
        return macaron;
    }
}
