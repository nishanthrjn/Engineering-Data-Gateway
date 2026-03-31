using EngineeringGateway.API.Models;

namespace EngineeringGateway.API.Services;

public class LegacyDataService : ILegacyDataService
{
    public async Task<IEnumerable<EngineeringPart>> GetLegacyPartsAsync()
    {
        await Task.Delay(500); // Simulate database latency

        return new List<EngineeringPart>
        {
            new EngineeringPart 
            { 
                Id = Guid.NewGuid(), 
                PartNumber = "ENG-UNIT-A101", 
                Description = "Turbine Blade Section A", 
                Material = "Titanium Alloy", 
                IsCompliant = true, 
                WeightKg = 15.4, 
                LastInspected = DateTime.Now.AddDays(-5) 
            },
            new EngineeringPart 
            { 
                Id = Guid.NewGuid(), 
                PartNumber = "ENG-UNIT-B992", 
                Description = "High-Pressure Valve Housing", 
                Material = "Stainless Steel", 
                IsCompliant = false, 
                WeightKg = 82.1, 
                LastInspected = DateTime.Now.AddMonths(-2) 
            }
        };
    }
}