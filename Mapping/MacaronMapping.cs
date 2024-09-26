using System;
using DonMacaron.DTOs;
using DonMacaron.DTOs.MacaronsDto;
using DonMacaron.Entities;

namespace DonMacaron.Mapping;

public static class MacaronMapping
{
    public static Macaron ToEntity(this CreateMacaronDto createMacaronDto, List<Ingredient> ingredients)
    {
        return new Macaron{
            Taste = createMacaronDto.Taste,
            Description = createMacaronDto.Description,
            Price = createMacaronDto.Price,
            AdvertismentPrice = createMacaronDto.AdvertismentPrice,
            IsXl = createMacaronDto.IsXl,
            IsCurrentlyUnavailable = createMacaronDto.IsCurrentlyUnavailable,
            PictureLink = createMacaronDto.PictureLink,
            Ingredients = ingredients
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
            UpdatedAt = m.UpdatedAt
        };
    }
}
