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

    public async Task<List<Inhouse>> GetAllInHouse()
    {
      return await _context.InHouseParts.ToListAsync();
    }

    public async Task<List<Outsourced>> GetAllOutsourced()
    {
      return await _context.OutSourcedParts.ToListAsync();
    }

    public async Task<Inhouse> GetInhouseById(int id)
    {
      return await _context.InHouseParts.Where(q => q.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Outsourced> GetOutSourcedById(int id)
    {
      return await _context.OutSourcedParts.Where(q => q.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Inhouse> AddItem(Inhouse part)
    {
      _context.Add(part);
      await _context.SaveChangesAsync();
      return part;
    }

    public async Task<Outsourced> AddItem(Outsourced part)
    {
      _context.Add(part);
      await _context.SaveChangesAsync();
      return part;
    }

    public async Task<Inhouse> UpdateItem(Inhouse part)
    {
      Inhouse current = await GetInhouseById(part.Id);
      current.Name = part.Name;
      current.Price = part.Price;
      current.InStock = part.InStock;
      current.Min = part.Min;
      current.Max = part.Max;
      current.MachineId = part.MachineId;
      _context.Update(current);
      await _context.SaveChangesAsync();
      return current;
    }

    public async Task<Outsourced> UpdateItem(Outsourced part)
    {
      Outsourced current = await GetOutSourcedById(part.Id);
      current.Name = part.Name;
      current.Price = part.Price;
      current.InStock = part.InStock;
      current.Min = part.Min;
      current.Max = part.Max;
      current.CompanyName = part.CompanyName;
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
