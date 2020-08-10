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
    Task<List<Inhouse>> GetAllInHouse();
    /// <summary>
    /// Get All Out Sourced Parts from DB
    /// </summary>
    Task<List<Outsourced>> GetAllOutsourced();
    /// <summary>
    /// Get Part from DB by Id
    /// </summary>
    Task<Inhouse> GetInhouseById(int id);
    /// <summary>
    /// Get Part from DB by Id
    /// </summary>
    Task<Outsourced> GetOutSourcedById(int id);
    /// <summary>
    /// Add Part to DB
    /// </summary>
    Task<Inhouse> AddItem(Inhouse part);
    /// <summary>
    /// Add Part to DB
    /// </summary>
    Task<Outsourced> AddItem(Outsourced part);
    /// <summary>
    /// Update Part in DB
    /// </summary>
    Task<Inhouse> UpdateItem(Inhouse part);
    /// <summary>
    /// Delete Part from DB by Id
    /// </summary>
    Task<Outsourced> UpdateItem(Outsourced part);
    /// <summary>
    /// Delete Part from DB by Id
    /// </summary>
    Task Delete(int id);
  }
}
