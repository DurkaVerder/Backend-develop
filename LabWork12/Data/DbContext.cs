using Microsoft.EntityFrameworkCore;
using LabWork12.Models;

namespace LabWork12.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public static void Seed(MyDbContext context)
        {
            context.Products.AddRange(
                new Product { Name = "Пирожок", Price = 100 },
                new Product { Name = "Карты", Price = 200 },
                new Product { Name = "Мышь", Price = 300 }
            );
            context.SaveChanges();
        }
    }
}
