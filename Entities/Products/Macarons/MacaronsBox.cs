using System;
using System.ComponentModel;
using DonMacaron.Entities.Products.Macarons;

namespace DonMacaron.Entities;

public class MacaronsBox : AuditableEntity
{
    public Guid Id {get; set;}
    public required string PublicUrl {get; set;}
    public required MacaronsBoxVersion CurrentVersion{get; set;}
    public required Guid CurrentVersionId {get; set;}
    public List<MacaronsBoxVersion> MacaronsBoxVersions {get; set;} = [];
}

