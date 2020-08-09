using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using C698_Product_WPF.Data.EntityModels;

namespace C698_Product_WPF.Data.DTOs
{
  public class ProductDTO : BaseDTO
  {
    [Range(0.00, 99999999999.99)]
    public decimal Price { get; set; }

    public int InStock { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }
    public List<PartProduct> Parts { get; set; }

    public ProductDTO() { }

    public ProductDTO(Product product)
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
