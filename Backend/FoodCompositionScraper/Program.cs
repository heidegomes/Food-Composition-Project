using FoodCompositionScraper.Data;
using FoodCompositionScraper.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrando o contexto do banco de dados
builder.Services.AddDbContext<FoodContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Registrando o serviço de WebScraperService (use apenas uma linha de registro)
builder.Services.AddScoped<WebScraperService>();
builder.Services.AddScoped<FoodService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://localhost:5057")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
// app.UseAuthorization();

app.MapControllers();

// Endpoint de teste
app.MapGet("/", () => "API is running!");

// Endpoint para chamar o serviço de web scraping
app.MapGet("/scrape-food", async (WebScraperService scraperService) =>
{
    var foodData = await scraperService.ScrapeFoodDataAsync();
    return Results.Ok(foodData);
});

app.Run();
