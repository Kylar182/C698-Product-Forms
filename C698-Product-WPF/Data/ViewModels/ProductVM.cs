using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using C698_Product_WPF.Data.EntityModels;
using C698_Product_WPF.Data.EntityModels.Types;

namespace C698_Product_WPF.Data.ViewModels
{
  public class ProductVM : BaseVM
  {
    [Range(0.00, 99999999999.99)]
    public decimal Price { get; set; }

    public int InStock { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }

    public CUD CUD { get; set; }

    public List<PartProduct> Parts { get; set; }

    public ProductVM() { }

    public ProductVM(Product product)
    {
      Id = product.Id;
      Name = product.Name;
      Price = product.Price;
      InStock = product.InStock;
      Min = product.Min;
      Max = product.Max;
      Parts = product.Parts;
    }
  }
}
