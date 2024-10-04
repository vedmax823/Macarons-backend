namespace DonMacaron.Entities;

public class Allergen : AuditableEntity
{
    public Guid Id {get; set;}
    public required string Name {get; set;}
    public string Link {get; set;} = "";
}
