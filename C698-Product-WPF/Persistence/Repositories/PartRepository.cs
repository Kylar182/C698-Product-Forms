using System;
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

    public async Task<List<InHouse>> GetAllInHouse()
    {
      return await _context.InHouseParts.ToListAsync();
    }

    public async Task<List<OutSourced>> GetAllOutSourced()
    {
      return await _context.OutSourcedParts.ToListAsync();
    }

    public async Task<InHouse> GetInHouseById(int id)
    {
      return await _context.InHouseParts.Where(q => q.Id == id).FirstOrDefaultAsync();
    }

    public async Task<OutSourced> GetOutSourcedById(int id)
    {
      return await _context.OutSourcedParts.Where(q => q.Id == id).FirstOrDefaultAsync();
    }

    public async Task<InHouse> AddItem(InHouse part)
    {
      part.Id = await GetLatestId();
      _context.Add(part);
      await _context.SaveChangesAsync();
      return part;
    }

    public async Task<OutSourced> AddItem(OutSourced part)
    {
      part.Id = await GetLatestId();
      _context.Add(part);
      await _context.SaveChangesAsync();
      return part;
    }

    public async Task<InHouse> UpdateItem(InHouse part)
    {
      InHouse current = await GetInHouseById(part.Id);

      if (current != null)
      {
        current.Name = part.Name;
        current.Price = part.Price;
        current.InStock = part.InStock;
        current.Min = part.Min;
        current.Max = part.Max;
        current.MachineId = part.MachineId;
        _context.Update(current);
        await _context.SaveChangesAsync();
      }
      else
      {
        await Delete(part.Id);
        current = new InHouse()
        {
          Id = part.Id,
          Name = part.Name,
          Price = part.Price,
          InStock = part.InStock,
          Min = part.Min,
          Max = part.Max,
          MachineId = part.MachineId
        };
        _context.Add(current);
        await _context.SaveChangesAsync();
      }
      return current;
    }

    public async Task<OutSourced> UpdateItem(OutSourced part)
    {
      OutSourced current = await GetOutSourcedById(part.Id);

      if (current != null)
      {
        current.Name = part.Name;
        current.Price = part.Price;
        current.InStock = part.InStock;
        current.Min = part.Min;
        current.Max = part.Max;
        current.CompanyName = part.CompanyName;
        _context.Update(current);
        await _context.SaveChangesAsync();
      }
      else
      {
        await Delete(part.Id);
        current = new OutSourced()
        {
          Id = part.Id,
          Name = part.Name,
          Price = part.Price,
          InStock = part.InStock,
          Min = part.Min,
          Max = part.Max,
          CompanyName = part.CompanyName
        };
        _context.Add(current);
        await _context.SaveChangesAsync();
      }
      return current;
    }

    public async Task Delete(int id)
    {
      InHouse removeInHouse = await GetInHouseById(id);
      if (removeInHouse != null)
        _context.Remove(removeInHouse);
      else
        _context.Remove(await GetOutSourcedById(id));

      await _context.SaveChangesAsync();
    }

    private async Task<int> GetLatestId()
    {
      int inHouseMax = await _context.InHouseParts.MaxAsync(prop => prop.Id);
      int outSourceMax = await _context.OutSourcedParts.MaxAsync(prop => prop.Id);
      return (Math.Max(inHouseMax, outSourceMax) + 1);
    }
  }
}
