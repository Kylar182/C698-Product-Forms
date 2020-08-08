using System.Collections.Generic;
using System.Threading.Tasks;
using C698_Product_WPF.Data.DTOs;
using C698_Product_WPF.Data.EntityModels;

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
    Task<PartDTO> AddItem(Part part);
    /// <summary>
    /// Update Part in DB
    /// </summary>
    Task<PartDTO> UpdateItem(Part part);
    /// <summary>
    /// Delete Part from DB by Id
    /// </summary>
    Task Delete(int id);
  }
}
