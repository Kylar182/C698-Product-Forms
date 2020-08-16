using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using C698_Product_WPF.Data.DTOs;
using C698_Product_WPF.Data.EntityModels.Types;
using C698_Product_WPF.Data.ViewModels;

namespace C698_Product_WPF.Data.EntityModels
{
  public class Product : Base
  {
    [Range(0.00, 99999999999.99)]
    public decimal Price { get; set; }

    public int InStock { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }

    public List<PartProduct> Parts { get; set; }

    public Product() { }

    public Product(ProductVM product)
    {
      if (product.CUD != CUD.Add)
        Id = product.Id.Value;

      Name = product.Name;
      Price = product.Price;
      InStock = product.InStock;
      Min = product.Min;
      Max = product.Max;
      Parts = new List<PartProduct>();
      foreach (PartProductDTO dto in product.PartProducts.ToList())
        Parts.Add(new PartProduct(dto, product.Id));
    }

    private void AddAssociatedPart(Part part) 
    {
      PartProduct partadd = new PartProduct()
      {
        ProductId = Id,
        PartId = part.Id
      }

      Parts.Add(partadd);
    }

    private bool RemoveAssociatedPart(int id)
    {      
      return Parts.Remove(id);
    }

    private Part LookupAssociatedPart(int id)
    {
      return new InHouse();
    }
  }
}
