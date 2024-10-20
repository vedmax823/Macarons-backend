using System;
using System.ComponentModel;

namespace DonMacaron.Entities;

public class MacaronsBox : AuditableEntity
{
    public Guid Id {get; set;}
    public required string Name {get; set;}
    public required string PictureLink{get; set;}
    public bool IsXl {get; set;} = true;
    public string Description {get; set;} = "";
    public Int32 NumberOfMacarons {get; set;}
    public float Price{get; set;} = 2.5f;
    public float AdvertismentPrice {get; set;} = 2.5f;
    public List<Macaron> Macarons{get; set;} = [];
}
