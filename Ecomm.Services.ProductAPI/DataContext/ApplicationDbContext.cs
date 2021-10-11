using Ecomm.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecomm.Services.ProductAPI.DataContext
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // products table
    public DbSet<Product> Products { get; set; }

    /// <summary>
    /// used to seed the data
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Product>().HasData(new Product
      {
        Id = 1,
        Name = "Pide",
        Price = 10,
        Description = "Greatest pide of all time",
        ImageUrl = "",
        CategoryName = "Appetizer",
      });
    }
  }
}