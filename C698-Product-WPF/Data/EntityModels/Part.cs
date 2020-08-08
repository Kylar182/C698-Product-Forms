using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using C698_Product_WPF.Data.EntityModels.Types;
using C698_Product_WPF.Data.ViewModels;

namespace C698_Product_WPF.Data.EntityModels
{
  public class Part : Base
  {
    [Range(0.00, 99999999999.99)]
    public decimal Price { get; set; }

    public int InStock { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }

    public string InOut { get; set; }

    public Source Source { get; set; }

    public List<PartProduct> Products { get; set; }

    public Part() { }

    public Part(PartVM part)
    {
      if (part.CUD != CUD.Add)
        Id = part.Id.Value;

      Name = part.Name;
      Price = part.Price;
      InStock = part.InStock;
      Min = part.Min;
      Max = part.Max;
      Source = part.Source;
      if (part.Source == Source.InHouse)
        InOut = part.MachineId.ToString();
      else
        InOut = part.CompanyName;
    }
  }
}
