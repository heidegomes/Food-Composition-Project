using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodCompositionScraper.Services; // Caso o WebScraperService esteja neste namespace
using FoodCompositionScraper.Models;
using Microsoft.EntityFrameworkCore; // Para ToListAsync e FindAsync

namespace FoodCompositionScraper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly WebScraperService _webScraperService;
        private readonly FoodService _foodService;

        // Injeção de dependência
        public FoodController(WebScraperService webScraperService, FoodService foodService)
        {
            _webScraperService = webScraperService;
            _foodService = foodService;
        }

        // Endpoint para obter todos os dados de alimentos
        [HttpGet] // Rota: /api/food
        public async Task<ActionResult<IEnumerable<FoodData>>> GetFoods()
        {
            // Verifica se o WebScraperService tem uma lista ou coleção de Foods
            var foods = await _foodService.GetFoodsAsync();
            if (foods == null || foods.Count == 0)
            {
                return NotFound("Nenhum alimento encontrado.");
            }

            return Ok(foods);
        }

        // Endpoint para obter um alimento específico pelo código
        [HttpGet("{code}")] // Rota: /api/food/{code}
        public async Task<ActionResult<FoodData>> GetFood(string code)
        {
            // Busca o alimento pelo ID
            var food = await _foodService.GetFoodByCodeAsync(code);

            if (food == null)
            {
                return NotFound();
            }

            return Ok(food);
        }
    }
}
