using Microsoft.EntityFrameworkCore;
using FoodCompositionScraper.Data;
using Microsoft.Extensions.DependencyInjection;
using FoodCompositionScraper.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrando o serviço de WebScraperService (use apenas uma linha de registro)
builder.Services.AddScoped<WebScraperService>();

// Registrando o contexto do banco de dados
builder.Services.AddDbContext<FoodContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

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
