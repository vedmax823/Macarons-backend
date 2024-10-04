using System;

namespace DonMacaron.Entities;

public class Ingredient : AuditableEntity
{
    public Guid Id {get; set;}
    public required string Name {get; set;}
    public Allergen? Allergen {get; set;}
    public bool ContainsGluten {get; set;} = false;
    public List<Macaron> Macarons {get; set;} = [];
}
