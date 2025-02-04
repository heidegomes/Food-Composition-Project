using FoodCompositionScraper.Data;
using FoodCompositionScraper.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodCompositionScraper.Services
{
    public class FoodService
    {
        private readonly FoodContext _context;

        public FoodService(FoodContext context)
        {
            _context = context;
        }

        public async Task<List<FoodData>> GetFoodsAsync()
        {
            return await _context.Foods
                .Include(f => f.Components)
                .ToListAsync();
        }

        public async Task<FoodData> GetFoodByIdAsync(int id)
        {
            return await _context.Foods.FindAsync(id);
        }

        public async Task<FoodData> GetFoodByCodeAsync(string code)
        {
            return await _context.Foods
                .Include(f => f.Components)
                .FirstOrDefaultAsync(f => f.Code == code);
        }
        
        // Método para adicionar alimentos ao banco de dados
        public async Task AddFoodAsync(FoodData food)
        {
            _context.Foods.Add(food);
            await _context.SaveChangesAsync();
        }

        // Método para adicionar múltiplos alimentos de uma vez ao banco de dados
        public async Task AddFoodsAsync(List<FoodData> foods)
        {
            _context.Foods.AddRange(foods);
            await _context.SaveChangesAsync();
        }        
    }
}