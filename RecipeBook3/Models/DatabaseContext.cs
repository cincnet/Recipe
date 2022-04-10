//using Microsoft.EntityFrameworkCore.Fram

using Microsoft.EntityFrameworkCore;

namespace RecipeBook3.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost,1433; Database=Recipe;User=sa; Password=Strong.Pwd-123");
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

    }
}
