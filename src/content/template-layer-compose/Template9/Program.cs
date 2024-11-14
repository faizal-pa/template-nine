var builder = WebApplication.CreateBuilder(args);

// 01. Add Configuration Providers
// If values in appsettings.local.json are a higher priority than values from a
// cloud-based configuration provider, add the cloud-based configuration
// provider first. Otherwise, add the cloud-based configuration provider last.
// (e.g. Azure Key Vault or AWS Secrets Manager)
builder.Configuration.AddJsonFile("appsettings.local.json", optional: true);

// 02. Configure Logging

// 03. Configure Health Checks

// 04. Configure Problem Details

// 05. Register Services (Managers, Mappers, Engines and Infrastructure, etc.)

builder.Services.AddControllers();

// 07. Configure Options

// 08. Configure Swagger/OpenAPI
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build the application
var app = builder.Build();

// 09. Add Problem Details Middleware
// Learn more about Problem Details at https://tools.ietf.org/html/rfc7807

// 10. Add Health Checks Middleware
// Learn more about Health Checks at https://aka.ms/aspnetcore-health

// 11. Add Swagger UI Middleware
// Learn more about Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// 12. Add Optional Middleware
// app.UseHttpsRedirection();
// app.UseAuthorization();

// 13. Map Controllers
app.MapControllers();

// Run the application
app.Run();
