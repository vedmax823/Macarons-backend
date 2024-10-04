using System.Security.Cryptography.X509Certificates;

namespace DonMacaron.DTOs.MacaronsDto;

public class MacaronDto
{
    public Guid Id {get; set;}
    public required string Taste {get; set;}
    public string PictureLink {get; set;} = "";
    public float Price {get; set;}
    public float AdvertismentPrice {get; set;}
    public string Description {get; set;} = "";
    public Guid[] IngredientsIds {get; set;} = [];
    public bool IsXl {get; set;}
    public bool IsCurrentlyUnavailable {get; set;}
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public required string PublicUrl {get; set;}

}