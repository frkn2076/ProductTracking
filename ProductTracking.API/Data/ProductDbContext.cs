using Microsoft.EntityFrameworkCore;
using ProductTracking.API.Data.Entities;
using ProductTracking.API.Utils.Enums;

namespace ProductTracking.API.Data;

public class ProductDbContext(DbContextOptions<ProductDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var colors = Enum.GetValues<Color>();

        modelBuilder.Entity<Product>().HasData(Enumerable.Range(1, 100).Select(x =>
            new Product
            {
                Id = x,
                Name = $"Name-{Random.Shared.Next(10)}",
                Color = colors[Random.Shared.Next(1, colors.Length)],
                Size = Random.Shared.Next(10,100),
                Brand = $"Company-ABC{Random.Shared.Next(10)}",
                Barcode = Guid.NewGuid().ToString()
            })
        );
    }
}
