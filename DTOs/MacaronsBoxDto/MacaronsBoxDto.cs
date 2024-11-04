using System.ComponentModel.DataAnnotations;
using DonMacaron.Entities;

namespace DonMacaron.DTOs.MacaronsBoxDto;

public record class MacaronsBoxDto
(
    Guid Id,
    string Name,
    string Description,
    string PictureLink,
    float Price,
    float AdvertismentPrice,
    bool IsXl,
    bool IsCurrentlyUnavailable,
    Int32 NumberOfMacarons,
    string PublicUrl,
    bool IsFixed,
    List<SmallMacaronsSet> SmallMacaronsSets,
    int Version,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt
);
