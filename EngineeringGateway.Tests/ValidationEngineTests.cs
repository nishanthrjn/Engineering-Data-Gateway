using EngineeringGateway.API.Models;
using EngineeringGateway.API.Services;
using Xunit;

namespace EngineeringGateway.Tests;

public class ValidationEngineTests
{
    private readonly IndustrialSafetyValidationEngine _engine;

    public ValidationEngineTests()
    {
        _engine = new IndustrialSafetyValidationEngine();
    }

    [Fact] // This attribute tells .NET this is a test
    public void ValidatePart_ShouldFail_WhenHeavyPartExceedsInspectionWindow()
    {
        // 1. Arrange: Setup a "Dangerous" part (Heavy + Old Inspection)
        var part = new EngineeringPart
        {
            PartNumber = "FAIL-001",
            WeightKg = 60, 
            LastInspected = DateTime.Now.AddDays(-40) // Older than 30 days
        };

        // 2. Act: Run it through the engine
        var result = _engine.ValidatePart(part);

        // 3. Assert: Check if it was rejected as expected
        Assert.False(result.IsValid);
        Assert.Contains("exceeds the 30-day safety inspection window", result.Message);
    }

    [Fact]
    public void ValidatePart_ShouldPass_WhenPartIsLightAndRecent()
    {
        // 1. Arrange: Setup a "Safe" part
        var part = new EngineeringPart
        {
            PartNumber = "PASS-001",
            WeightKg = 10,
            LastInspected = DateTime.Now,
            IsCompliant = true,
            Material = "Aluminum"
        };

        // 2. Act
        var result = _engine.ValidatePart(part);

        // 3. Assert
        Assert.True(result.IsValid);
    }
}