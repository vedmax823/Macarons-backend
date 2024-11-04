using System;

namespace DonMacaron.Entities.Products.Macarons;

public class MacaronsVersion : AuditableEntity
{
    public Guid Id {get; set;}
    public required string Taste{get; set;}
    public string PictureLink{get; set;} = "";
    public float Price{get; set;} = 2.5f;
    public float AdvertismentPrice {get; set;} = 2.5f;
    public string Description {get; set;} = "";
    public List<Ingredient> Ingredients {get; set;} = [];
    public bool IsXl {get; set;} = false;
    public bool IsCurrentlyAvailable {get; set;} = true;
    public int Version {get; set;} = 1;
}
