using System;

namespace DonMacaron.Entities;

public class Ingredient
{
    public Guid Id {get; set;}
    public required string Name {get; set;}
    public Allergen? Allergen {get; set;}
    public bool ContainsGluten {get; set;} = false;
}
