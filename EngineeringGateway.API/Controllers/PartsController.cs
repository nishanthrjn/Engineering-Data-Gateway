using EngineeringGateway.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringGateway.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PartsController : ControllerBase
{
    private readonly ILegacyDataService _legacyService;

    // The service is automatically "Injected" here by the framework
    public PartsController(ILegacyDataService legacyService)
    {
        _legacyService = legacyService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _legacyService.GetLegacyPartsAsync();
        return Ok(data);
    }
}