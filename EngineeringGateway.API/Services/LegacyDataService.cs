using EngineeringGateway.API.Models;

namespace EngineeringGateway.API.Services;

public class LegacyDataService : ILegacyDataService
{
    public async Task<IEnumerable<EngineeringPart>> GetLegacyPartsAsync()
    {
        // We simulate a 500ms delay to mimic a slow legacy database
        await Task.Delay(500);

        return new List<EngineeringPart>
        {
            new EngineeringPart 
            { 
                Id = Guid.NewGuid(), 
                PartNumber = "SIE-TRB-001", 
                Description = "Turbine Blade Section A", 
                Material = "Titanium Alloy", 
                IsCompliant = true, 
                WeightKg = 15.4, 
                LastInspected = DateTime.Now.AddDays(-5) 
            },
            new EngineeringPart 
            { 
                Id = Guid.NewGuid(), 
                PartNumber = "SIE-VLV-992", 
                Description = "High-Pressure Valve Housing", 
                Material = "Stainless Steel", 
                IsCompliant = false, 
                WeightKg = 82.1, 
                LastInspected = DateTime.Now.AddMonths(-1) 
            }
        };
    }
}