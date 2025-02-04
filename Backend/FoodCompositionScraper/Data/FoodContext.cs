using Microsoft.EntityFrameworkCore;
using FoodCompositionScraper.Models;

namespace FoodCompositionScraper.Data
{
    public class FoodContext : DbContext
    {
        public FoodContext(DbContextOptions<FoodContext> options) : base(options)
        {
        }
        
        public DbSet<FoodData> Foods { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);
        // }
    }
}
