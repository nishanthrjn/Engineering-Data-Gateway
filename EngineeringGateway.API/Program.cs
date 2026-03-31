using EngineeringGateway.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection registrations
builder.Services.AddScoped<ILegacyDataService, LegacyDataService>();
builder.Services.AddScoped<IValidationEngine, IndustrialSafetyValidationEngine>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();