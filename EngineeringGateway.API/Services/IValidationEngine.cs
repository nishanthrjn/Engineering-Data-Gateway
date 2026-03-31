using EngineeringGateway.API.Models;

namespace EngineeringGateway.API.Services;

public interface IValidationEngine
{
    (bool IsValid, string Message) ValidatePart(EngineeringPart part);
}