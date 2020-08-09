using System;
using System.ComponentModel.DataAnnotations;
using C698_Product_WPF.Data.EntityModels;
using C698_Product_WPF.Data.EntityModels.Types;

namespace C698_Product_WPF.Data.DTOs
{
  public class PartProductDTO : BaseDTO
  {
    [Range(0.00, 99999999999.99)]
    public decimal Price { get; set; }

    public int InStock { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }

    public CUD CUD { get; set; }

    public PartProductDTO() { }

    public PartProductDTO(Part part, CUD cud)
    {
      Name = part.Name;
      Price = part.Price;
      InStock = part.InStock;
      Min = part.Min;
      Max = part.Max;
      CUD = cud;
    }

    public PartProductDTO(PartProduct part, CUD cud)
    {
      Id = part.Id;
      Name = part.Part.Name;
      Price = part.Part.Price;
      InStock = part.Part.InStock;
      Min = part.Part.Min;
      Max = part.Part.Max;
      CUD = cud;
    }
  }
}
