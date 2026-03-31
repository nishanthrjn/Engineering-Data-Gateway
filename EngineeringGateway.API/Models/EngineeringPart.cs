namespace EngineeringGateway.API.Models;

public class EngineeringPart
{
    public Guid Id { get; set; }
    public string PartNumber { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Material { get; set; } = string.Empty;
    public bool IsCompliant { get; set; } 
    public double WeightKg { get; set; }
    public DateTime LastInspected { get; set; }
}