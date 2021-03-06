﻿using System.Collections.Generic;
using System.Threading.Tasks;
using C698_Product_WPF.Data.EntityModels;

namespace C698_Product_WPF.Persistence.Repositories.Interfaces
{
  public interface IPartRepository
  {
    /// <summary>
    /// Get All Parts from DB
    /// </summary>
    Task<List<Part>> GetAll();
    /// <summary>
    /// Get Part from DB by Id
    /// </summary>
    Task<Part> GetById(int id);
    /// <summary>
    /// Add Part to DB
    /// </summary>
    Task<Part> AddItem(Part part);
    /// <summary>
    /// Update Part in DB
    /// </summary>
    Task<Part> UpdateItem(Part part);
    /// <summary>
    /// Delete Part from DB by Id
    /// </summary>
    Task Delete(int id);
  }
}
