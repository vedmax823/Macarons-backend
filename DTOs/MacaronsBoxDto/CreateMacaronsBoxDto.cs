using System.ComponentModel.DataAnnotations;

namespace DonMacaron.DTOs.MacaronsBoxDto;

public record class CreateMacaronsBoxDto
(
    [Required] string Name,
    string Description,
    string PictureLink,
    float Price,
    float AdvertismentPrice,
    bool IsXl,
    bool IsCurrentlyUnavailable,
    Int32 NumberOfMacarons,
    bool IsFixed,
    List<MacaronSetDto> SmallMacaronsSets
);

public class MacaronSetDto
{
    public int Count { get; set; }
    public Guid MacaronId { get; set; }
}
