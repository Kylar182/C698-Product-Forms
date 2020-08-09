using System.Collections.Generic;
using System.Threading.Tasks;
using C698_Product_WPF.Data.DTOs;

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
    Task<List<PartDTO>> GetAll();
    /// <summary>
    /// Get Part from DB by Id
    /// </summary>
    Task<PartDTO> GetById(int id);
    /// <summary>
    /// Add Part to DB
    /// </summary>
    Task<PartDTO> AddItem(PartDTO part);
    /// <summary>
    /// Update Part in DB
    /// </summary>
    Task<PartDTO> UpdateItem(PartDTO part);
    /// <summary>
    /// Delete Part from DB by Id
    /// </summary>
    Task Delete(int id);
  }
}
