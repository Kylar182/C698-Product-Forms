using System;
using System.ComponentModel.DataAnnotations;
using C698_Product_WPF.Data.EntityModels;
using C698_Product_WPF.Data.EntityModels.Types;

namespace C698_Product_WPF.Data.DTOs
{
  public class PartDTO : BaseDTO
  {
    [Range(0.00, 99999999999.99)]
    public decimal Price { get; set; }

    public int InStock { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }

    public Source Source { get; set; }

    public int MachineId { get; set; }

    public string CompanyName { get; set; }

    public PartDTO() { }

    public PartDTO(Part part)
    {
      Id = part.Id;
      Name = part.Name;
      Price = part.Price;
      InStock = part.InStock;
      Min = part.Min;
      Max = part.Max;
      Source = part.Source;
      if (part.Source == Source.InHouse)
        MachineId = Convert.ToInt32(part.InOut);
      else
        CompanyName = part.InOut;
    }
  }
}
