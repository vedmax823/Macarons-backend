using System;

namespace DonMacaron.Entities;

public class SmallMacaronsSet
{
    public int Id { get; set; }
    public int Count { get; set; }
    public Guid MacaronId {get; set;}
    public required Macaron Macaron { get; set; }
}