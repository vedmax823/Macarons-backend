namespace DonMacaron.Entities;

public class Allergen
{
    public Guid Id {get; set;}
    public required string Name {get; set;}
    public string Link {get; set;} = "";
}
