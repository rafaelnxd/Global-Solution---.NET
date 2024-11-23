using AdvancedBusinessDevelopment.Repositories;
using GlobalSolution.Data;
using GlobalSolution.Repositories; // Add this line to include the Repositories namespace

using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

// Register the repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Advanced Business Development API", Version = "v1" });
});

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Advanced Business Development API V1");
    });
}

app.UseHttpsRedirection(); // Adds HTTPS redirection

app.UseAuthorization();

app.MapControllers();

app.Run();
