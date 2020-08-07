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
  }
}
