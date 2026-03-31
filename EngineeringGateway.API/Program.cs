using EngineeringGateway.API.Services;

var builder = WebApplication.CreateBuilder(args);

// --- 1. Register Services (Dependency Injection) ---
builder.Services.AddControllers(); // CRITICAL: This tells .NET to look for your PartsController
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register your custom services
builder.Services.AddScoped<ILegacyDataService, LegacyDataService>();
builder.Services.AddScoped<IValidationEngine, SiemensStandardValidationEngine>();

var app = builder.Build();

// --- 2. Configure Middleware ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// CRITICAL: This maps the attribute routes like [Route("api/[controller]")]
app.MapControllers(); 

app.Run();