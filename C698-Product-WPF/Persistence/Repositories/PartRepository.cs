using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C698_Product_WPF.Data.EntityModels;
using C698_Product_WPF.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace C698_Product_WPF.Persistence.Repositories
{
  public class PartRepository : IPartRepository
  {
    private readonly InventoryDBContext _context;

    public PartRepository(InventoryDBContext context)
    {
      _context = context;
    }

    public async Task<List<Part>> GetAll()
    {
      return await _context.Parts.ToListAsync();
    }

    public async Task<Part> GetById(int id)
    {
      return await _context.Parts.Where(q => q.Id == id).Include(prop => prop.Products).FirstOrDefaultAsync();
    }

    public async Task<Part> AddItem(Part part)
    {
      _context.Add(part);
      await _context.SaveChangesAsync();
      return part;
    }

    public async Task<Part> UpdateItem(Part part)
    {
      Part current = await GetById(part.Id);
      current.Name = part.Name;
      current.Price = part.Price;
      current.InStock = part.InStock;
      current.Min = part.Min;
      current.Max = part.Max;
      current.Source = part.Source;
      current.InOut = part.InOut;
      _context.Update(current);
      await _context.SaveChangesAsync();
      return current;
    }

    public async Task Delete(int id)
    {
      _context.Remove(await GetById(id));
      await _context.SaveChangesAsync();
    }
  }
}
