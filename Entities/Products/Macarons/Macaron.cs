
using DonMacaron.Entities.Products.Macarons;
using System.ComponentModel.DataAnnotations.Schema;
namespace DonMacaron.Entities;

public class Macaron : AuditableEntity
{
    public Guid Id {get; set;}
    public required string PublicUrl {get; set;}
    public List<MacaronsVersion> MacaronsVersions {get; set;} = [];

    public Guid CurrentVersionId { get; set; }
    public required virtual MacaronsVersion CurrentVersion { get; set; }
}
