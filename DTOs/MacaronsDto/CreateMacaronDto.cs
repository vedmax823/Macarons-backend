using System.ComponentModel.DataAnnotations;

namespace DonMacaron.DTOs;

public record class CreateMacaronDto
(
    [Required] string Taste,
    string Description,
    string PictureLink,
    float Price,
    float AdvertismentPrice,
    bool IsXl,
    bool IsCurrentlyAvailable,
    List<Guid> IngredientsIds
);
