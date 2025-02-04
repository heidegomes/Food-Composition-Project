using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodCompositionScraper.Services; // Caso o WebScraperService esteja neste namespace
using FoodCompositionScraper.Models;
using FoodCompositionScraper.Utils;
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
        [HttpGet] // Rota: /api/food?page=1&size=10
        public async Task<ActionResult<PagedResult<FoodData>>> GetFoods(
            [FromQuery] int? page = 1, 
            [FromQuery] int? size = 10, 
            [FromQuery] string? search = null)
        {
            
            var actualPage = page.GetValueOrDefault(1);
            var actualSize = size.GetValueOrDefault(10);

            
            if (page <= 0 || size <= 0)
            {
                return BadRequest("Os parâmetros 'page' e 'size' devem ser maiores que zero.");
            }

            // Verifica se o WebScraperService tem uma lista ou coleção de Foods
            var pagedResult = await _foodService.GetFoodsAsync(actualPage, actualSize, search);
            if (pagedResult.TotalItems == 0)
            {
                return NotFound("Nenhum alimento encontrado.");
            }

            return Ok(pagedResult);
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
