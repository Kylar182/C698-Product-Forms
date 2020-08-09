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
      return await _context.Products.Where(q => q.Id == id)
                                      .Include(prop => prop.Parts)
                                        .ThenInclude(p => p.Part)
                                        .FirstOrDefaultAsync();
    }

    public async Task<Product> AddItem(Product product)
    {
      List<PartProduct> Parts = product.Parts;
      product.Parts = new List<PartProduct>();
      _context.Products.Add(product);

      await _context.SaveChangesAsync();

      foreach (PartProduct part in Parts)
        part.ProductId = product.Id;

      _context.PartProducts.AddRange(Parts);

      await _context.SaveChangesAsync();

      return product;
    }

    public async Task<Product> UpdateItem(Product product)
    {
      Product selected = await GetById(product.Id);
      List<int> selectedPartIds = selected.Parts.Select(prop => prop.Id).ToList();

      selected.Name = product.Name;
      selected.Price = product.Price;
      selected.InStock = product.InStock;
      selected.Min = product.Min;
      selected.Max = product.Max;
      foreach (PartProduct part in product.Parts)
      {
        if (selectedPartIds.Contains(part.Id))
          continue;

        _context.Add(part);
      }

      _context.Update(selected);
      await _context.SaveChangesAsync();

      List<int> productPartIds = product.Parts.Select(prop => prop.Id).ToList();

      foreach (PartProduct part in selected.Parts)
      {
        if (productPartIds.Contains(part.Id))
          continue;

        _context.Remove(part);
      }

      await _context.SaveChangesAsync();

      return product;
    }

    public async Task Delete(int id)
    {
      Product product = await GetById(id);
      foreach (PartProduct part in product.Parts)
        _context.Remove(part);

      await _context.SaveChangesAsync();

      _context.Remove(product);

      await _context.SaveChangesAsync();
    }
  }
}
