public class FoodService
{
  private readonly FoodDbContext _context;

  public WebScraperService(FoodDbContext context)
  {
      _context = context;
  }

  public async Task<List<Food>> GetFoodsAsync()
  {
      // Aqui você pode retornar a lista de alimentos de um banco de dados ou de uma coleção
      return await _context.Foods.ToListAsync(); // Exemplo usando EF Core
  }

  public async Task<Food> GetFoodByIdAsync(int id)
  {
      return await _context.Foods.FindAsync(id); // Busca pelo ID
  }
}