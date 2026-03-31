using EngineeringGateway.API.Models;

namespace EngineeringGateway.API.Services;

public interface ILegacyDataService
{
    Task<IEnumerable<EngineeringPart>> GetLegacyPartsAsync();
}