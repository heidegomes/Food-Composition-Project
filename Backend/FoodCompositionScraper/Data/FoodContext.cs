using Microsoft.EntityFrameworkCore;
using FoodCompositionScraper.Models;

namespace FoodCompositionScraper.Data
{
    public class FoodContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }

        public FoodContext(DbContextOptions<FoodContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Você pode configurar entidades aqui, se necessário.
        }
    }
}
