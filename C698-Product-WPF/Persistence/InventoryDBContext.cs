using C698_Product_WPF.Data.EntityModels;
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

    public DbSet<InHouse> InHouseParts { get; set; }

    public DbSet<OutSourced> OutSourcedParts { get; set; }

    public DbSet<PartProduct> PartProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Product>().HasData(GetProducts());
      builder.Entity<InHouse>().HasData(GetInHouseParts());
      builder.Entity<OutSourced>().HasData(GetOutSourcedParts());
      builder.Entity<PartProduct>();
      base.OnModelCreating(builder);
    }

    private Product[] GetProducts()
    {
      return new Product[]
      {
        new Product
        {
          Id = 1, Name = "Red Bicycle", InStock = 15, Price = 11.44M, Min = 1, Max = 25
        },
        new Product
        {
          Id = 2, Name = "Yellow Bicycle", InStock = 19, Price = 9.66M, Min = 1, Max = 20
        },
        new Product
        {
          Id = 3, Name = "Blue Bicycle", InStock = 5, Price = 12.77M, Min = 1, Max = 25
        }
      };
    }

    private InHouse[] GetInHouseParts()
    {
      return new InHouse[]
      {
        new InHouse
        {
          Id = 1, Name = "Wheel", InStock = 15, Price = 12.11M, Min = 5, Max = 25, MachineId = 12
        },
        new InHouse
        {
          Id = 2, Name = "Pedal", InStock = 11, Price = 8.22M, Min = 1, Max = 25, MachineId = 29
        }
      };
    }

    private OutSourced[] GetOutSourcedParts()
    {
      return new OutSourced[]
      {
        new OutSourced
        {
          Id = 3, Name = "Chain", InStock = 12, Price = 8.33M, Min = 5, Max = 25, CompanyName = "Smith Foundry, Inc."
        },
        new OutSourced
        {
          Id = 4, Name = "Seat", InStock = 8, Price = 4.55M, Min = 2, Max = 15, CompanyName = "Smith Foundry, Inc."
        }
      };
    }
  }
}
