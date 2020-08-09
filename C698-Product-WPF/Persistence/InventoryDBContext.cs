using C698_Product_WPF.Data.EntityModels;
using C698_Product_WPF.Data.EntityModels.Types;
using Microsoft.EntityFrameworkCore;

namespace C698_Product_WPF.Persistence
{
  public class InventoryDBContext : DbContext
  {
    public InventoryDBContext(DbContextOptions<InventoryDBContext> options) : base(options)
    {
      Database.EnsureCreated();
    }

    public DbSet<Product> Products { get; set; }

    public DbSet<Inhouse> InHouseParts { get; set; }

    public DbSet<Outsourced> OutSourcedParts { get; set; }

    public DbSet<PartProduct> PartProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Product>().HasData(GetProducts());
      builder.Entity<Inhouse>().HasData(GetInHouseParts());
      builder.Entity<Outsourced>().HasData(GetOutsourcedParts());
      builder.Entity<PartProduct>();
      base.OnModelCreating(builder);
    }

    private Product[] GetProducts()
    {
      return new Product[]
      {
        new Product
        {
          Id = 1, Name = "Red Bicycle", Price = 11.44M, Min = 1, Max = 25
        },
        new Product
        {
          Id = 2, Name = "Yellow Bicycle", Price = 9.66M, Min = 1, Max = 20
        },
        new Product
        {
          Id = 3, Name = "Blue Bicycle", Price = 12.77M, Min = 1, Max = 25
        }
      };
    }

    private Inhouse[] GetInHouseParts()
    {
      return new Inhouse[]
      {
        new Inhouse
        {
          Id = 1, Name = "Wheel", InStock = 15, Price = 12.11M, Min = 5, Max = 25, MachineId = 12
        },
        new Inhouse
        {
          Id = 2, Name = "Pedal", InStock = 11, Price = 8.22M, Min = 1, Max = 25, MachineId = 29
        }        
      };
    }

    private Outsourced[] GetOutsourcedParts()
    {
      return new Outsourced[]
      {
        new Outsourced
        {
          Id = 3, Name = "Chain", InStock = 12, Price = 8.33M, Min = 5, Max = 25, CompanyName = "Smith Foundry, Inc."
        },
        new Outsourced
        {
          Id = 4, Name = "Seat", InStock = 8, Price = 4.55M, Min = 2, Max = 15, CompanyName = "Smith Foundry, Inc."
        }
      };
    }
  }
}
