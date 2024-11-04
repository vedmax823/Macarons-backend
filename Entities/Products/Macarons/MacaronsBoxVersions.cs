using System;

namespace DonMacaron.Entities.Products.Macarons;

public class MacaronsBoxVersion : AuditableEntity
{
    public Guid Id {get; set;}
    public required string Name {get; set;}
    public required string PictureLink{get; set;}
    public bool IsXl {get; set;} = true;
    public string Description {get; set;} = "";
    public Int32 NumberOfMacarons {get; set;}
    public float Price{get; set;} = 2.5f;
    public float AdvertismentPrice {get; set;} = 2.5f;
    public bool IsCurrentlyUnavailable {get; set;} = true;
    public bool IsFixed {get; set;} = false;
    public List<SmallMacaronsSet> SmallMacaronsSets { get; set; } = [];
    public int Version{get; set;} = 1;

}
