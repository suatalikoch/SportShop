using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ShopContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Subcategory> Subcategories { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Favourite> Favourites { get; set; }

        public ShopContext()
        { }

        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // This will only run when the context is instantiated outside of a test
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;user=root;database=sportshop");
            }
        }

        public static ShopContext CreateTestContext()
        {
            // This method will create a new instance of the context with an in-memory database
            var options = new DbContextOptionsBuilder<ShopContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            return new ShopContext(options);
        }
    }
}
