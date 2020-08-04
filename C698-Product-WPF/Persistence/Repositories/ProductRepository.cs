using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C698_Product_WPF.Data.EntityModels;
using C698_Product_WPF.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace C698_Product_WPF.Persistence.Repositories
{
  public class ProductRepository : IProductRepository
  {
    private readonly InventoryDBContext _context;

    public ProductRepository(InventoryDBContext context)
    {
      _context = context;
    }

    public async Task<List<Product>> GetAll()
    {
      return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetById(int id)
    {
      return await _context.Products.Where(q => q.Id == id).Include(prop => prop.Parts).FirstOrDefaultAsync();
    }

    public async Task<Product> AddItem(Product product)
    {
      _context.Add(product);
      await _context.SaveChangesAsync();
      return product;
    }

    public async Task<Product> UpdateItemAsync(Product product)
    {
      _context.Update(product);
      await _context.SaveChangesAsync();
      return product;
    }

    public async Task Delete(int id)
    {
      _context.Remove(await GetById(id));
      await _context.SaveChangesAsync();
    }
  }
}
