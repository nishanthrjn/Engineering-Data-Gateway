using EngineeringGateway.API.Models;
using EngineeringGateway.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringGateway.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PartsController : ControllerBase
{
    private readonly ILegacyDataService _legacyService;
    private readonly IValidationEngine _validationEngine;

    public PartsController(ILegacyDataService legacyService, IValidationEngine validationEngine)
    {
        _legacyService = legacyService;
        _validationEngine = validationEngine;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _legacyService.GetLegacyPartsAsync();
        return Ok(data);
    }

    [HttpGet("compliance-report")]
    public async Task<IActionResult> GetComplianceReport()
    {
        var parts = await _legacyService.GetLegacyPartsAsync();

        var report = parts.Select(p => {
            var validationResult = _validationEngine.ValidatePart(p);
            return new {
                Part = p.PartNumber,
                Material = p.Material,
                Status = validationResult.IsValid ? "Approved" : "Rejected",
                Details = validationResult.Message
            };
        });

        return Ok(report);
    }
}