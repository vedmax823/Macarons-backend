
namespace DonMacaron.Entities;

public class Macaron : AuditableEntity
{
    public Guid Id {get; set;}
    public required string Taste{get; set;}
    public string PictureLink{get; set;} = "";
    public float Price{get; set;} = 2.5f;
    public float AdvertismentPrice {get; set;} = 2.5f;
    public string Description {get; set;} = "";
    public List<Ingredient> Ingredients {get; set;} = [];
    public bool IsXl {get; set;} = false;
    public bool IsCurrentlyUnavailable {get; set;} = true;
    public string PublicUrl {get; set;} = "";
}
