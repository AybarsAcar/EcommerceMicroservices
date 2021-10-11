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
  }
}