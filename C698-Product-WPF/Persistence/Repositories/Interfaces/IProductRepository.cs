using System.Collections.Generic;
using System.Threading.Tasks;
using C698_Product_WPF.EntityModels;

namespace C698_Product_WPF.Persistence.Repositories.Interfaces
{
  /// <summary>
  /// Product Repository
  /// </summary>
  public interface IProductRepository
  {
    /// <summary>
    /// Get All Products from DB
    /// </summary>
    Task<List<Product>> GetAll();
    /// <summary>
    /// Get Product from DB by Id
    /// </summary>
    Task<Product> GetById(int id);
    /// <summary>
    /// Add Product to DB
    /// </summary>
    Task<Product> AddItem(Product product);
    /// <summary>
    /// Update Product in DB
    /// </summary>
    Task<Product> UpdateItemAsync(Product product);
    /// <summary>
    /// Delete Product from DB by Id
    /// </summary>
    Task Delete(int id);
  }
}
