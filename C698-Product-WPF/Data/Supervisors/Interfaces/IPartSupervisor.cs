using System.Collections.Generic;
using System.Threading.Tasks;
using C698_Product_WPF.Data.ViewModels;

namespace C698_Product_WPF.Data.Supervisors.Interfaces
{
  /// <summary>
  /// Part Repository
  /// </summary>
  public interface IPartSupervisor
  {
    /// <summary>
    /// Get All Parts from DB
    /// </summary>
    Task<List<PartVM>> GetAll();
    /// <summary>
    /// Get an Part from DB by Id
    /// </summary>
    Task<PartVM> GetById(int id);
    /// <summary>
    /// Add Part to DB
    /// </summary>
    Task<PartVM> AddItem(PartVM part);
    /// <summary>
    /// Update Part in DB
    /// </summary>
    Task<PartVM> UpdateItem(PartVM part);
    /// <summary>
    /// Delete Part from DB by Id
    /// </summary>
    Task Delete(int id);
  }
}
