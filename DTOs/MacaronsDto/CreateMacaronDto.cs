using System.ComponentModel.DataAnnotations;

namespace DonMacaron.DTOs;

public record class CreateMacaronDto
(
    [Required] string Taste,
    string Description,
    string PictureLink,
    float Price,
    float AdvertismentPrice,
    List<Guid> IngredientsIds,
    bool IsXl,
    bool IsCurrentlyUnavailable
);
