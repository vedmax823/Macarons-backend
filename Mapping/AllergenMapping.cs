
using System.Net.Http.Headers;
using DonMacaron.Controllers;
using DonMacaron.DTOs;
using DonMacaron.DTOs.AllergenDto;
using DonMacaron.Entities;


namespace DonMacaron.Mapping;

public static class AllergenMapping
{
    public static Allergen ToEntity(this CreateAllergenDto createAllergenDto)
    {
        return new Allergen{
            Name = createAllergenDto.Name,
            Link = createAllergenDto.Link
        };
    }

    public static  Allergen NewEntity(this Allergen allergen, CreateAllergenDto updateAllergenDto)
    {
        allergen.Name = updateAllergenDto.Name;
        allergen.Link = updateAllergenDto.Link;
        return allergen;
    }

    public static AllergenDto ToAllergenDto(this Allergen allergen)
    {
        return new AllergenDto(
            allergen.Id,
            allergen.Name,
            allergen.Link,
            allergen.CreatedAt,
            allergen.UpdatedAt
        );
    }

}
