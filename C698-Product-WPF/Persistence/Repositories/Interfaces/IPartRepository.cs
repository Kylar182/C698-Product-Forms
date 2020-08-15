using System.Collections.Generic;
using System.Threading.Tasks;
using C698_Product_WPF.Data.EntityModels;

namespace C698_Product_WPF.Persistence.Repositories.Interfaces
{
  public interface IPartRepository
  {
    /// <summary>
    /// Get All In House Parts from DB
    /// </summary>
    Task<List<InHouse>> GetAllInHouse();
    /// <summary>
    /// Get All Out Sourced Parts from DB
    /// </summary>
    Task<List<OutSourced>> GetAllOutSourced();
    /// <summary>
    /// Get Part from DB by Id
    /// </summary>
    Task<InHouse> GetInHouseById(int id);
    /// <summary>
    /// Get Part from DB by Id
    /// </summary>
    Task<OutSourced> GetOutSourcedById(int id);
    /// <summary>
    /// Add Part to DB
    /// </summary>
    Task<InHouse> AddItem(InHouse part);
    /// <summary>
    /// Add Part to DB
    /// </summary>
    Task<OutSourced> AddItem(OutSourced part);
    /// <summary>
    /// Update Part in DB
    /// </summary>
    Task<InHouse> UpdateItem(InHouse part);
    /// <summary>
    /// Delete Part from DB by Id
    /// </summary>
    Task<OutSourced> UpdateItem(OutSourced part);
    /// <summary>
    /// Delete Part from DB by Id
    /// </summary>
    Task Delete(int id);
  }
}
