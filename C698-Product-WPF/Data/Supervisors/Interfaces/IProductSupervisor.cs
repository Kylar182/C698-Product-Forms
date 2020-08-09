using System.Collections.Generic;
using System.Threading.Tasks;
using C698_Product_WPF.Data.DTOs;
using C698_Product_WPF.Data.EntityModels;

namespace C698_Product_WPF.Data.Supervisors.Interfaces
{
  /// <summary>
  /// Product Repository
  /// </summary>
  public interface IProductSupervisor
  {
    /// <summary>
    /// Get All Products from DB
    /// </summary>
    Task<List<ProductDTO>> GetAll();
    /// <summary>
    /// Get All Parts from DB
    /// </summary>
    Task<List<Part>> GetAllParts();
    /// <summary>
    /// Get Product from DB by Id
    /// </summary>
    Task<ProductDTO> GetById(int id);
    /// <summary>
    /// Add Product to DB
    /// </summary>
    Task<ProductDTO> AddItem(Product part);
    /// <summary>
    /// Update Product in DB
    /// </summary>
    Task<ProductDTO> UpdateItem(Product part);
    /// <summary>
    /// Delete Product from DB by Id
    /// </summary>
    Task Delete(int id);
  }
}
