using MangoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MangoApi.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Iphone",
                Price = 999,
                Description = "new phone  from apple",
                ImageUrl = "https://dotnetmastery1110.blob.core.windows.net/mango/2023-01-01%2015.47.08.jpg",
                CategoryName = "Phones"
            });
        }
    }
}