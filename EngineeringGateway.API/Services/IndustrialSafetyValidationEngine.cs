using EngineeringGateway.API.Models;

namespace EngineeringGateway.API.Services;

public class IndustrialSafetyValidationEngine : IValidationEngine
{
    public (bool IsValid, string Message) ValidatePart(EngineeringPart part)
    {
        // Rule: Heavy parts (>50kg) need inspection every 30 days
        if (part.WeightKg > 50 && part.LastInspected < DateTime.Now.AddDays(-30))
        {
            return (false, "High-mass component exceeds the 30-day safety inspection window.");
        }

        // Rule: Critical material integrity check
        if (part.Material.Contains("Titanium") && !part.IsCompliant)
        {
            return (false, "Critical alloy integrity check failed.");
        }

        return (true, "Approved: Meets Industrial Safety Standards");
    }
}