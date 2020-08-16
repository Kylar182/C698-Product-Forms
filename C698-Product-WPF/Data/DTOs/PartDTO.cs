using System;
using System.ComponentModel.DataAnnotations;
using C698_Product_WPF.Data.EntityModels;
using C698_Product_WPF.Data.EntityModels.Types;
using C698_Product_WPF.Data.ViewModels;

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

    public PartDTO(InHouse part)
    {
      Id = part.Id;
      Name = part.Name;
      Price = part.Price;
      InStock = part.InStock;
      Min = part.Min;
      Max = part.Max;
      Source = Source.InHouse;
      MachineId = part.MachineId;
      CompanyName = "";
    }

    public PartDTO(OutSourced part)
    {
      Id = part.Id;
      Name = part.Name;
      Price = part.Price;
      InStock = part.InStock;
      Min = part.Min;
      Max = part.Max;
      Source = Source.OutSourced;
      MachineId = 0;
      CompanyName = part.CompanyName;
    }

    public PartDTO(PartVM part)
    {
      if (part.CUD != CUD.Add)
        Id = part.Id.Value;

      Name = part.Name;
      Price = part.Price;
      InStock = part.InStock;
      Min = part.Min;
      Max = part.Max;
      Source = part.Source;
      MachineId = part.MachineId;
      CompanyName = part.CompanyName;
    }
  }
}
